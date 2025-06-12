using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject[] bullet;
    public Transform muzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Fire()); // Start the firing coroutine
    }
    
    IEnumerator Fire()
    {
        while(true)
        {
            int bulletIndex = Random.Range(0, bullet.Length); // Randomly select a bullet type
            Instantiate(bullet[bulletIndex], muzzle);

            yield return new WaitForSeconds(2f); // Wait for 1 second before firing the next bullet
        }
    }


}
