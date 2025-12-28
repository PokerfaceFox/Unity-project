using UnityEngine;

public class CubeLifeTimer : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private float _timeAfterTouch;
    private float _maxLifeTime;
    private bool _isTimerRunning;
    private CubePool _pool;

    private void OnEnable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched += OnPlatformTouched;
        }

        FindPoolIfNeeded();
    }

    private void OnDisable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched -= OnPlatformTouched;
        }

        _isTimerRunning = false;
        _timeAfterTouch = 0f;
    }

    private void OnPlatformTouched(Cube cube)
    {
        _maxLifeTime = Random.Range(2f, 5f);
        _timeAfterTouch = 0f;
        _isTimerRunning = true;
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            _timeAfterTouch += Time.deltaTime;

            if (_timeAfterTouch >= _maxLifeTime)
            {
                _isTimerRunning = false;

                if (_pool != null)
                {
                    _pool.ReturnCube(_cube);
                }
                else
                {
                    FindPoolIfNeeded();
                    if (_pool != null)
                    {
                        _pool.ReturnCube(_cube);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private void FindPoolIfNeeded()
    {
        if (_pool == null)
        {
            _pool = FindObjectOfType<CubePool>();
        }
    }
}