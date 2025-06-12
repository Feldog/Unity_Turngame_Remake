using UnityEngine;

public class PlayerEntity : DefaultEntity
{
    [Header("Attack Status")]
    public float attackDamage = 10f;
    public float impulseForce = 20f;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 10f;
            Destroy(collision.gameObject); // Destroy the bullet on collision
        }
    }
}
