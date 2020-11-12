using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Action state;
    public Direction direction;
    public float slippingTime = 1f;
    public float maxSpeed = 15f;

    public float slippingSpeed = 1f;

    public float descendingHPower = 2f;
    public float descendingVPower = 3f;
    public float glidingHPower = 1f;
    public float glidingVPower = 2f;


    private float holdingTime = 0f;
    private bool ticked = false;
    private int side = 0;
    private Vector2 lastSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ticked)
        {
            holdingTime += Time.deltaTime;
            if (holdingTime >= slippingTime)
            {
                state = Action.Slipping;
                ticked = false;
            }
        }
        //Debug.Log(state);

        if (Input.GetMouseButtonDown(0))
        {
            ticked = false;
            if (state == Action.Holding || state == Action.Slipping)
            {
                state = Action.Descending;
                
            }
            else if (state == Action.Descending)
            {
                state = Action.Gliding;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (state == Action.Gliding)
            {
                state = Action.Descending;
            }
        }

        if (direction == Direction.Right)
        {
            side = 1;
        }
        if (direction == Direction.Left)
        {
            side = -1;
        }

        Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
    }


    private void FixedUpdate()
    {
        switch (state)
        {
            case Action.Holding:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
            case Action.Slipping:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * slippingSpeed;
                break;
            case Action.Descending:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * side * descendingHPower + Vector2.down * descendingVPower;
                break;
            case Action.Gliding:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * side * glidingHPower + Vector2.down * glidingVPower;
                break;
            default:
                break;
        }
        //if (GetComponent<Rigidbody2D>().velocity.magnitude <= maxSpeed)
        //{
        //    lastSpeed = GetComponent<Rigidbody2D>().velocity;
        //}
        //else
        //{
        //    GetComponent<Rigidbody2D>().velocity = lastSpeed;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LTree") && !ticked)
        {
            state = Action.Holding;
            direction = Direction.Right;
            StartTimer();
        }
        if (collision.gameObject.CompareTag("RTree") && !ticked)
        {
            state = Action.Holding;
            direction = Direction.Left;
            StartTimer();
        }
    }


    void StartTimer()
    {
        ticked = true;
        holdingTime = 0;
    }



}

public enum Action { Holding, Slipping, Descending, Gliding };
public enum Direction { Left, Right };