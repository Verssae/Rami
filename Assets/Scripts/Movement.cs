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

    public float glidingHPower = 2f;
    public float glidingVPower = 3f;
    public float rollingHPower = 1f;
    public float rollingVPower = 2f;

    [SerializeField]
    private bool isDevelopment = false;

    private float holdingTime = 0f;
    private bool ticked = false;
    private int side = 0;
    private Vector2 lastSpeed;
    private Touch touch;

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

        if (isDevelopment)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ticked = false;
                if (state == Action.Holding || state == Action.Slipping)
                {
                    state = Action.Gliding;

                }
                else if (state == Action.Gliding)
                {
                    state = Action.Rolling;
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
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    ticked = false;
                    if (state == Action.Holding || state == Action.Slipping)
                    {
                        state = Action.Gliding;

                    }
                    else if (state == Action.Gliding)
                    {
                        state = Action.Rolling;
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

        SetAinm(state);
        SetDirection(direction);
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
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
        //if (GetComponent<Rigidbody2D>().velocity.magnitude <= maxSpeed)
        //{
        //    lastSpeed = GetComponent<Rigidbody2D>().velocity;
        //}
        //else
        //{
        //    GetComponent<Rigidbody2D>().velocity = lastSpeed;
        //}
    }

    void SetAinm(Action action)
    {
        switch (action)
        {
            case Action.Holding:
                GetComponent<Animator>().SetBool("Holding", true);
                GetComponent<Animator>().SetBool("Slipping", false);
                GetComponent<Animator>().SetBool("Gliding", false);
                GetComponent<Animator>().SetBool("Rolling", false);
                GetComponent<Animator>().SetBool("Ending", false);
                break;
            case Action.Slipping:
                GetComponent<Animator>().SetBool("Holding", false);
                GetComponent<Animator>().SetBool("Slipping", true);
                GetComponent<Animator>().SetBool("Gliding", false);
                GetComponent<Animator>().SetBool("Rolling", false);
                GetComponent<Animator>().SetBool("Ending", false);
                break;
            case Action.Gliding:
                GetComponent<Animator>().SetBool("Holding", false);
                GetComponent<Animator>().SetBool("Slipping", false);
                GetComponent<Animator>().SetBool("Gliding", true);
                GetComponent<Animator>().SetBool("Rolling", false);
                GetComponent<Animator>().SetBool("Ending", false);
                break;
            case Action.Rolling:
                GetComponent<Animator>().SetBool("Holding", false);
                GetComponent<Animator>().SetBool("Slipping", false);
                GetComponent<Animator>().SetBool("Gliding", false);
                GetComponent<Animator>().SetBool("Rolling", true);
                GetComponent<Animator>().SetBool("Ending", false);
                break;
            case Action.Ending:
                GetComponent<Animator>().SetBool("Holding", false);
                GetComponent<Animator>().SetBool("Slipping", false);
                GetComponent<Animator>().SetBool("Gliding", false);
                GetComponent<Animator>().SetBool("Rolling", false);
                GetComponent<Animator>().SetBool("Ending", true);
                break;
            default:
                break;
        }
    }

    void SetDirection(Direction dir)
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

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            state = Action.Ending;
            GameObject.Find("GameManager").GetComponent<GameManager>().End = true;
        }
    }


    void StartTimer()
    {
        ticked = true;
        holdingTime = 0;
    }



}

public enum Action { Holding, Slipping, Gliding, Rolling, Ending };
public enum Direction { Left, Right };