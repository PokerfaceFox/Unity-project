using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Counter _counter;
    [SerializeField] private CounterView _counterView;

    void Awake()
    {
        _counter.Initialize(_inputReader);

        _counterView.Initialize(_counter);
    }
}