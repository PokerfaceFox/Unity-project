using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text counterText;

    private int count = 0;
    private bool isCounting = false;
    private Coroutine countingCoroutine;

    void Start()
    {
        UpdateUIText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    void ToggleCounting()
    {
        if (isCounting)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    void StartCounting()
    {
        isCounting = true;
        countingCoroutine = StartCoroutine(CountCoroutine());
    }

    void StopCounting()
    {
        isCounting = false;

        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }
    }

    IEnumerator CountCoroutine()
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(0.5f);
            count++;
            UpdateUIText();
        }
    }

    void UpdateUIText()
    {
        if (counterText != null)
        {
            counterText.text = "—четчик: " + count;
        }

        Debug.Log("—четчик: " + count);
    }
}
