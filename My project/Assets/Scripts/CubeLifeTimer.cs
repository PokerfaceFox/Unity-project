using UnityEngine;
using System.Collections;

public class CubeLifeTimer : MonoBehaviour
{
    private Cube _cube;
    private Coroutine _lifeCoroutine;

    private void OnEnable()
    {
        _cube = GetComponent<Cube>();
        if (_cube != null)
        {
            _cube.PlatformTouched += HandlePlatformTouch;
        }
    }

    private void OnDisable()
    {
        if (_cube != null)
        {
            _cube.PlatformTouched -= HandlePlatformTouch;
        }

        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
        }
    }

    private void HandlePlatformTouch()
    {
        float lifeTime = Random.Range(2f, 5f);
        _lifeCoroutine = StartCoroutine(StartCountdown(lifeTime));
    }

    private IEnumerator StartCountdown(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        if (_cube != null)
        {
            _cube.NotifyLifeEnded();
        }

        _lifeCoroutine = null;
    }
}