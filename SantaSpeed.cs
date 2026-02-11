using UnityEngine;

public class SantaSpeed : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private Vector3 moveDirection = new Vector3(1, 0, 0);

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("냠");
        }
    }
    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}