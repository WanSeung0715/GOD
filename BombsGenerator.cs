using UnityEngine;

public class BombsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bombPrefabs;
    public void SpawnBomb()
    {
        if (bombPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, bombPrefabs.Length);
            GameObject selectedPrefab = bombPrefabs[randomIndex];

            GameObject newBomb = Instantiate(selectedPrefab, transform.position, transform.rotation, this.transform);

            Rigidbody rb = newBomb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    void Start()
    {
        SpawnBomb();
    }
}
