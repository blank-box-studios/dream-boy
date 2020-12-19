using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Dreamboy_Script : MonoBehaviour
{

    
    [Header("Movement")]
    public float jumpForce;
    public float flyForce;
    public float movementForce;
    public Rigidbody2D rb;
    public bool onGround;
    public bool moveRight;
    public bool moveLeft;
    public int jumpcounter;
    public bool dead;

    GameManagerScript gm;

    [Header("Stats")]
    public int health;
    public Text healthtext;
    public bool hero; //0 is normal 1 is hero

    [Header("Animation")]
    public Animator anim;
    public SpriteRenderer gun;
    public SpriteRenderer herosprite;
    public SpriteRenderer dreamboysprite;

    [Header("Shooting")]
    public GameObject bullet;
    public float fireRate;
    float waitTillNextbullet;


    [Header("Shit")]
    public BoxCollider2D attackTrigDB;
    public BoxCollider2D attackTrigHero;
    private float heroTime;
    private bool flag;

    private float deathTimer;


    private void Start()
    {
        dead = false;
        gm = FindObjectOfType<GameManagerScript>();
        health = 100;
    }
    private void Update()
    {
        healthtext.text = health.ToString();
        if (health <= 0)
        {
            die();
        }
        if (!dead)
        {
            if (rb.transform.position.y > 0.747)
            {
                deathTimer -= Time.deltaTime;
            }
            else
            {
                deathTimer = 5;
            }

            if (deathTimer < 0)
            {
                die();
            }


            ///SHOOTING///
            heroTime -= Time.deltaTime;
            if (heroTime < 0)
            {
                hero = false;
            }
            else
            {
                hero = true;
                if (flag)
                {
                    rb.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse);
                    flag = false;
                }


            }
            if (hero)
            {
                attackTrigDB.enabled = false;
                attackTrigHero.enabled = true;
                gun.enabled = false;
                dreamboysprite.enabled = false;
                herosprite.enabled = true;

                rb.gravityScale = 0.25f;
                if (Input.GetKeyDown("space"))
                {
                    rb.gravityScale = 1f;
                    rb.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                attackTrigDB.enabled = true;
                attackTrigHero.enabled = false;
                gun.enabled = true;
                dreamboysprite.enabled = true;
                herosprite.enabled = false;
                rb.gravityScale = 1f;
                if (Input.GetKey(KeyCode.Space))
                {
                    if (waitTillNextbullet <= 0)
                    {
                        Instantiate(bullet, transform.position, transform.rotation);
                        waitTillNextbullet = 1;
                    }
                }
                waitTillNextbullet -= Time.deltaTime * fireRate;

                if (onGround)
                {
                    rb.AddForce(Vector2.up * jumpForce);
                    onGround = false;
                }
                if (Input.GetKey("d"))
                {
                    rb.AddForce(Vector2.right * movementForce);

                }
                if (Input.GetKey("a"))
                {
                    rb.AddForce(Vector2.left * movementForce);
                }

            }
        }
    }


    public void getHurt()
    {
        health -= 10;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
            if (hero)
            {
                die();
            }
        {
            onGround = true;
        }   
        if (col.collider.CompareTag("Powerup"))
        {
            heroTime = 10;
            flag = true;
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }




    void die()
    {
        dead = true;
        gm.endGame();
    }

  
}
