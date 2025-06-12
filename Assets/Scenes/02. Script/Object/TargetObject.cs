using System.Collections;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float multipleSpeed = 0.1f;
    private Vector3 moveTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TargetMove());
    }

    IEnumerator TargetMove()
    {
        
        while(true)
        {
            moveTarget = new Vector3(Random.Range(-0.4f, 0.4f), transform.localPosition.y, transform.localPosition.z);

            while (Vector3.Distance(transform.localPosition, moveTarget) > 0.01f)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveTarget, moveSpeed * multipleSpeed * Time.deltaTime);
                yield return null; // Wait for the next frame
            }
            transform.localPosition = moveTarget;
            yield return new WaitForSeconds(0.5f); // Wait for 1 second before moving again
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Target hit by: " + collision.gameObject.name);
            GameManager.instance.Score += collision.gameObject.GetComponent<BulletScript>().getPointed; // Increment the score in GameManager
            Destroy(collision.gameObject);
        }
    }
}
