using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private int side;
    // Start is called before the first frame update
    void Start()
    {
        side = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            side = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            side = 1;
        } 
        else
        {
            side = 0;
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(side * speed, -1 * speed);
    }
}
