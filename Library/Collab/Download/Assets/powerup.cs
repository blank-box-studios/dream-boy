using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    Vector3 initPos = new Vector3(-0.307000011f, 0.34799999f, 0);
    private float waitTillNextPowerUp = 10;
    public GameObject powerUp;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (waitTillNextPowerUp <= 0)
        {
            GameObject temp = powerUp;
            powerUp = Instantiate(temp, initPos, transform.rotation);
            Destroy(temp);
            waitTillNextPowerUp = Random.Range(9,15);
        }
        waitTillNextPowerUp -= Time.deltaTime;
    }
}
