using UnityEngine;

public class DefaultController : MonoBehaviour
{
    protected Rigidbody rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
       // Physics-related updates can be handled here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
