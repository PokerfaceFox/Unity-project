using UnityEngine;
using System.Collections;

public class CubeLifeTimer : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private Coroutine _lifeCoroutine;

    private void OnEnable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched += OnPlatformTouched;
        }
    }

    private void OnDisable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched -= OnPlatformTouched;
        }

        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
            _lifeCoroutine = null;
        }
    }

    private void OnPlatformTouched(Cube cube)
    {
        float lifeTime = Random.Range(2f, 5f);
        _lifeCoroutine = StartCoroutine(StartLifeCountdown(lifeTime));
    }

    private IEnumerator StartLifeCountdown(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        _cube.NotifyLifeEnded();

        _lifeCoroutine = null;
    }
}