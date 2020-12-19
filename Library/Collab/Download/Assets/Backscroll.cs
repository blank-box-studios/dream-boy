using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backscroll : MonoBehaviour
{
    public float scrollspeed;
    public float bound;

    public Vector2 resetPos;
    // Start is called before the first frame update
  

    private void Update()
    {
        transform.Translate(Vector2.left * scrollspeed * Time.deltaTime);

        if (transform.position.x < bound)
        {
            transform.position = resetPos;
        }
    }
}
