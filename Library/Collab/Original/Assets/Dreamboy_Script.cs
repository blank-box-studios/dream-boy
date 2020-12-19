using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreamboy_Script : MonoBehaviour
{

    private bool isGrounded= false;
    [Header("Movement")]
    public float jumpForce;
    public Rigidbody2D rb;
    bool isJumping;

    [Header("Stats")]
    public int health;
    public bool mode;

    [Header("Animation")]
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);


        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isGrounded) 
            {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }


}
