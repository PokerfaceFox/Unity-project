using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _counterText;
    private Counter _counter;

    public void Initialize(Counter counter)
    {
        _counter = counter;
        _counter.CounterUpdate += UpdateView;

        _counterText.text = "Count: ";
    }

    private void OnDestroy()
    {
        if (_counter != null)
        {
            _counter.CounterUpdate -= UpdateView;
        }
    }

    private void UpdateView(int newValue) 
    {
        _counterText.text = $"Count: {newValue}";
    }
}
