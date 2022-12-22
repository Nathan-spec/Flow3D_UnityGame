using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float movementSpeed = 6f;
    [SerializeField]float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        //Verical movement
        float verticalInput = Input.GetAxis("Vertical");

       rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

       if(Input.GetButtonDown("Jump") && IsGrounded())
       {
           Jump();
       }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    //Ground check
    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
