using UnityEngine;

public class ClickableCube : MonoBehaviour
{
    public GameObject CubePrefab;
    [SerializeField] private float splitChance = 1.0f;

    private void OnMouseDown()
    {
        float explosionForce = 5f;
        float reduction = 2.0f;
        int minCubes = 2;
        int maxCubes = 6;

        bool willSplit = (Random.value < splitChance);
        int randomAmount = Random.Range(minCubes, maxCubes + 1);

        if (willSplit)
        {
            for (int i = 0; i < randomAmount; i++)
            {
                GameObject newCube = Instantiate(CubePrefab, transform.position, Quaternion.identity);
                ClickableCube newCubeScript = newCube.GetComponent<ClickableCube>();

                newCubeScript.splitChance = splitChance / reduction;

                newCube.transform.localScale = transform.localScale / reduction;

                Renderer cubeRenderer = newCube.GetComponent<Renderer>();

                cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);

                Rigidbody rb = newCube.GetComponent<Rigidbody>();

                if (rb == null)
                {
                    rb = newCube.AddComponent<Rigidbody>();
                }
                rb.useGravity = true;

                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                rb.AddForce(randomDirection.normalized * explosionForce, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}