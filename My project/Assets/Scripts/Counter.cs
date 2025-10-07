using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentCount = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _halfSecond;
    private InputReader _inputReader;

    public event Action<int> OnCounterUpdate;

    private void Awake()
    {
        _halfSecond = new WaitForSeconds(0.5f);
    }

    public void Initialize(InputReader inputReader)
    {
        inputReader.ToggleCounter += ToggleCounting;
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.ToggleCounter -= ToggleCounting;
        }

        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _countingCoroutine = StartCoroutine(CountingRoutine());
        }
        else
        {
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
        }
    }

    private IEnumerator CountingRoutine() 
    {
        while (_isCounting) 
        {
            yield return _halfSecond;
            _currentCount++;
            OnCounterUpdate?.Invoke(_currentCount);
            Debug.Log($"Таймер: {_currentCount}");
        }
    }
}
