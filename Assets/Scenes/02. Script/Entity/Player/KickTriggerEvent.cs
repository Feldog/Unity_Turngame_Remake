using UnityEngine;

public class KickTriggerEvent : MonoBehaviour
{
    private PlayerEntity player;
    private void Start()
    {
        player = GetComponentInParent<PlayerEntity>();
        if (player == null)
        {
            Debug.LogError("PlayerEntity component not found in parent.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Kick Triggered: " + other.name);
            float randomForce = Random.Range(-0.5f, 0.5f);

            Rigidbody rb = other.GetComponentInParent<Rigidbody>();

            rb.linearVelocity = Vector3.zero; // Stop the bullet's movement
            rb.useGravity = true; // Enable gravity on the bullet
            rb.AddForce((transform.forward + Vector3.up).normalized * (player.impulseForce + randomForce), ForceMode.Impulse); // Apply a force in the forward direction
        }
    }
}
