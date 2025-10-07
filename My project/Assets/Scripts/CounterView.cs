using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    public void Initialize(Counter counter) 
    {
        counter.OnCounterUpdate += UpdateView;
        
        UpdateView((int)MouseButton.Left);
    }

    private void UpdateView(int newValue) 
    {
        _counterText.text = $"Count: {newValue}";
    }
}
