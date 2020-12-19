using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 2.0f;
    GameManagerScript gameManager;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SideWalls"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            if (!collision.GetComponent<GoblinScript>().dead)
            {
                collision.GetComponent<GoblinScript>().foundPlayer = true;
                collision.GetComponent<GoblinScript>().dead = true;
                collision.GetComponent<Animator>().SetTrigger("Dead");
                gameManager.score += 5;
                Destroy(collision.gameObject, 3);
            }
            
            Destroy(gameObject);
        }
    }
}
