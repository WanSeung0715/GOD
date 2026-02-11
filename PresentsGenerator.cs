using UnityEngine;

public class PresentsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] presentPrefabs;
    public void SpawnPresent()
    {
        if (presentPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, presentPrefabs.Length);
            GameObject selectedPrefab = presentPrefabs[randomIndex];

            GameObject newPresent = Instantiate(selectedPrefab, transform.position, transform.rotation, this.transform);

            Rigidbody rb = newPresent.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    void Start()
    {
        SpawnPresent();
    }
}
