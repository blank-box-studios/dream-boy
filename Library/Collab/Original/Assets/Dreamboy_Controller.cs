using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreamboy_Script : MonoBehaviour
{
    [Header("Movement")]
    public float movementForce;
    public float jumpForce;
    public Rigidbody2D rb;

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
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {

        }
    }


    void jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
