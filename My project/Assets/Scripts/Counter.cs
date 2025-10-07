using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> OnCounterUpdate;

    private int _currentCount = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;

    public void Initialize(InputReader inputReader)
    {
        inputReader.OnToggleCounter += ToggleCounting;
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
            yield return new WaitForSeconds(0.5f);
            _currentCount++;
            OnCounterUpdate?.Invoke(_currentCount);
            Debug.Log($"Таймер: {_currentCount}");
        }
    }
}
