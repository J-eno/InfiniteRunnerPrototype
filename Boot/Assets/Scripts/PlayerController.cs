using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movespeed = 2;
    public float jumpForce = 8;

    public bool grounded;
    public LayerMask whatIsGround;

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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
                
        }
	}

    void Jump()
    {
        if (grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }
}

