using UnityEngine;

public class CubeSplitCalculator : MonoBehaviour
{
    [SerializeField] private float _chanceReductionFactor = 2f;
    [SerializeField] private float _scaleDivider = 2f;

    public bool ShouldSplit(Cube cube)
    {
        return Random.value < cube.SplitChance;
    }

    public float CalculateNewSplitChance(float currentChance)
    {
        return currentChance / _chanceReductionFactor;
    }

    public Vector3 CalculateNewScale(Vector3 currentScale)
    {
        return currentScale / _scaleDivider;
    }
}