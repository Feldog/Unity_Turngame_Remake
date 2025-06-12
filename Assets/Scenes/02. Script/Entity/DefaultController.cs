using UnityEngine;

public class DefaultController : MonoBehaviour
{
    protected Rigidbody rb;
    protected Animator anim;

    public float moveSpeed = 5f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
        
    }

}
