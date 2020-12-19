using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float latSpeed;
    public float jumpForce;
    public Vector2 latteralForce;
    public Rigidbody2D dream;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")){
           
            dream.AddForce(latteralForce,ForceMode2D.Impulse);
        }
    }
}
