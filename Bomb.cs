using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    private Rigidbody sledRigidbody;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        GameObject sledObject = GameObject.FindGameObjectWithTag("Sled");
        if (sledObject != null)
        {
            sledRigidbody = sledObject.GetComponent<Rigidbody>();
        }
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        GameObject generatorObject = GameObject.FindWithTag("BombController");
        if (generatorObject != null)
        {
            BombsGenerator generator = generatorObject.GetComponent<BombsGenerator>();
            if (generator != null)
            {
                generator.SpawnBomb();
            }
        }

    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Destroy(gameObject, 8f);
    }
}

