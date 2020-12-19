using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreamboy_Script : MonoBehaviour
{
    [Header("Movement")]
    public float movementForce;
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
            //if (collides)
            //{
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //}
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * movementForce, ForceMode2D.Impulse);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * movementForce, ForceMode2D.Impulse);
        }
       

    }


}
