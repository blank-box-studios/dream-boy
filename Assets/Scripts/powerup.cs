using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    Vector3 initPos = new Vector3(-0.307000011f, 0.34799999f, 0);
    private float waitTillNextPowerUp=10;
    public GameObject powerUp;
    private Rigidbody2D rb;
    public float pUmoveForce;
    public float angSpeed;
    GameObject temp;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        rb = powerUp.GetComponent<Rigidbody2D>();
        if (waitTillNextPowerUp <= 0)
        {
            powerUp.transform.position = initPos;
            powerUp.GetComponent<SpriteRenderer>().enabled = true;
            powerUp.GetComponent<BoxCollider2D>().enabled = true;
            waitTillNextPowerUp = Random.Range(9, 15);
        }
        rb.AddForce(Vector2.right * Mathf.Sin(angSpeed * Time.deltaTime) * pUmoveForce);
        waitTillNextPowerUp -= Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        pUmoveForce = -pUmoveForce;
    }


}
