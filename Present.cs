using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Present : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
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
            rb.isKinematic = false;
        }
        GameObject generatorObject = GameObject.FindWithTag("GameController");
        if (generatorObject != null)
        {
            PresentsGenerator generator = generatorObject.GetComponent<PresentsGenerator>();
            if (generator != null)
            {
                generator.SpawnPresent();
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

