using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //player movement variables
    public float movespeed = 2;
    public float jumpForce = 8;
    public bool grounded;
    public LayerMask whatIsGround;

    //Touch Screen variables
    private float maxTime = 0.5f;
    private float minSwipeDistance = 25;
    float swipeDistance;
    float swipeTime;
    float startTime;
    float endTime;
    Vector3 startPos;
    Vector3 endPos;


    private Rigidbody2D playerRB;
    private Collider2D playerCol;

	// Use this for initialization
	void Start ()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.IsTouchingLayers(playerCol, whatIsGround);
        playerRB.velocity = new Vector2(movespeed, playerRB.velocity.y);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = (endTime - startTime);

                if (swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    Swipe();
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                /*
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = (endTime - startTime);

                if (swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    Swipe();
                }
                */
                touch = new Touch();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownActions();
        }
	}

    void Jump()
    {
        if (grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }

    void DownActions()
    {
        if (grounded)
        {
            //playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
        else
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, -jumpForce * 2);
        }
    }

    void Swipe()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //horizontal swipe
            if (distance.x > 0)
            {
                //Right swipe
            }
            else if (distance.x < 0)
            {
                //LeftSwipe
            }
        }

        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            //vertical swipe
            if (distance.y > 0)
            {
                //Up swipe
                Jump();
            }
            else if (distance.y < 0)
            {
                //DownSwipe
                DownActions();
            }
        }
    }
}

