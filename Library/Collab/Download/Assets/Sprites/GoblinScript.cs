using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int type; //0 is Normal 1 is armoured
    float speed, health;
    public float normalSpeed, armouredSpeed;
    public int normalHealth, armouredHealth;
    public bool foundPlayer;
    public bool dead;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        switch (type)
        {
            case 0:
                speed = normalSpeed;
                health = normalHealth;
                break;

            case 1:
                speed = armouredSpeed;
                health = armouredHealth;
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundPlayer)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            try
            {
                collision.GetComponent<Dreamboy_Script>().getHurt();
            }
            catch
            {

     
            }
            
            foundPlayer = true;
        }
        if (collision.CompareTag("DeadZone"))
        {
            print("found col");
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!dead)
            {
                anim.SetTrigger("Go Back");
                foundPlayer = false;
            }
            
        }
    }

  
}
