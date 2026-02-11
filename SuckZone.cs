using UnityEngine;

public class SuckZone : MonoBehaviour
{
    float pullForce = 1000f; // 빨아들이는 힘의 세기
    public Transform targetPoint; // 구멍위치

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gift") || other.CompareTag("Bomb"))
        {
            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
            if (otherRigidbody != null)
            {
                Vector3 direction = targetPoint.position - other.transform.position;
                otherRigidbody.AddForce(direction.normalized * pullForce * Time.fixedDeltaTime, ForceMode.Force);
            }
        }
    }
}

