using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce;

    public GameObject explosionEffect;
    public float Yset = 5.0f;

    private SoundController soundController;

    void Start()
    {
        soundController = FindFirstObjectByType<SoundController>();
    }
    
    public void BreakTheThing()
    {
        if (soundController != null)
        {
            soundController.PlayExplosionSound();    
        }
        
        if (explosionEffect != null)
        {
            Vector3 explosionPosition = transform.position + new Vector3(0, Yset, 0);
            Instantiate(explosionEffect, explosionPosition, Quaternion.identity);
        }

        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }

        Destroy(frac, 5f);

        Destroy(gameObject);
    }
        
}
