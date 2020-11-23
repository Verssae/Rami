using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum Action { Holding, Slipping, Gliding, Rolling, Ending };
    public enum Direction { Left, Right };

    [Header("Init State")]

    [SerializeField]
    private Action state = Action.Gliding;

    [SerializeField]
    private Direction direction = Direction.Left;

    [Header("Movement Parameters")]

    [Header("Sliping Parameters")]

    [SerializeField]
    private float slippingTime = 1f;

    [SerializeField]
    private float slippingSpeed = 1f;

    [Header("Gliding Parameters")]

    [SerializeField]
    private float glidingHPower = 2f;

    [SerializeField]
    private float glidingVPower = 3f;

    [Header("Rolling Parameters")]

    [SerializeField]
    private float rollingHPower = 1f;

    [SerializeField]
    private float rollingVPower = 2f;

    [Header("Development Mode")]

    public bool isDevelopment = false;

    private float holdingTime = 0f;
    private bool ticked = false;
    private int side = 0;


    private void Update()
    {
        if (ticked)
        {
            holdingTime += Time.deltaTime;
            if (holdingTime >= slippingTime)
            {
                ticked = false;
                state = Action.Slipping;
                
            }
        }

        if (isDevelopment)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ticked = false;
                if (state == Action.Holding || state == Action.Slipping)
                {
                    state = Action.Gliding;
                    Util.PlaySFX("Jump");
                }
                else if (state == Action.Gliding)
                {
                    state = Action.Rolling;
                    Util.PlaySFX("Rolling");
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                if (state == Action.Rolling)
                {
                    state = Action.Gliding;
                }
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    ticked = false;
                    if (state == Action.Holding || state == Action.Slipping)
                    {
                        state = Action.Gliding;
                        Util.PlaySFX("Jump");

                    }
                    else if (state == Action.Gliding)
                    {
                        state = Action.Rolling;
                        Util.PlaySFX("Rolling");
                    }

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (state == Action.Rolling)
                    {
                        state = Action.Gliding;
                    }

                }
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

        SetAinm();
        SetDirection(direction);
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
            case Action.Gliding:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * side * glidingHPower + Vector2.down * glidingVPower;
                break;
            case Action.Rolling:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * side * rollingHPower + Vector2.down * rollingVPower;
                break;
            default:
                break;
        }

    }

    private void SetAinm()
    {
        switch (state)
        {
            case Action.Holding:
                GetComponent<Animator>().SetInteger("State", 0);
                break;
            case Action.Slipping:
                GetComponent<Animator>().SetInteger("State", 1);
                break;
            case Action.Gliding:
                GetComponent<Animator>().SetInteger("State", 2);
                break;
            case Action.Rolling:
                GetComponent<Animator>().SetInteger("State", 3);
                break;
            case Action.Ending:
                GetComponent<Animator>().SetInteger("State", 4);
                break;
            default:
                break;
        }
    }

    private void SetDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                GetComponent<SpriteRenderer>().flipX = true;
                if (state == Action.Holding || state == Action.Slipping)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                break;
            case Direction.Right:
                GetComponent<SpriteRenderer>().flipX = false;
                if (state == Action.Holding || state == Action.Slipping)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            default:
                break;
        }
    }  
    
    private void StartTimer()
    {
        ticked = true;
        holdingTime = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LTree") && !ticked && state != Action.Slipping)
        {
            state = Action.Holding;
            direction = Direction.Right;
            StartTimer();
            Util.PlaySFX("Landing");
        }
        if (collision.gameObject.CompareTag("RTree") && !ticked && state != Action.Slipping)
        {
            state = Action.Holding;
            direction = Direction.Left;
            StartTimer();
            Util.PlaySFX("Landing");
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            state = Action.Ending;
            GameObject.Find("GameManager").GetComponent<GameManager>().End = true;
            Util.PlaySFX("GameOver");
        }
    }





}

