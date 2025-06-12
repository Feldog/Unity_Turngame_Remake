using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody component
    public float speed = 10f; // Speed of the bullet

    public int getPointed = 1;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the bullet
        rb.AddForce(speed * transform.forward, ForceMode.Impulse); // Apply an impulse force to the bullet in the forward direction

        Invoke("DestroyBullet", 10f);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // Destroy the bullet object
    }
}
