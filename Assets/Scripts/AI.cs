using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private GameObject player;
	private GameObject player2;
	private GameObject lowestPlayer;

    public float detectPlayer;

    public bool goingRight;
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public float timeBetweenJump;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isWalled;
    public Transform wallCheckL;
    public Transform wallCheckR;
    public float checkRadius_Wall;
    public LayerMask whatIsWall;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		player2 = GameObject.FindGameObjectWithTag("Player2");

		rb = gameObject.GetComponent<Rigidbody2D>();
        goingRight = true;
        wallCheckL.gameObject.SetActive(false);
    }


	public void Update()
	{
		if (player == null && player2 == null)
		{
			return;
		}

		if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().multi)
		{
			if (player == null || player2 == null)
			{
				if (player == null)
				{
					lowestPlayer = player2;
				}
				else
				{
					lowestPlayer = player;
				}
			}
			else
			{
				if (player.transform.position.y > player2.transform.position.y)
				{
					lowestPlayer = player2;
				}
				else if (player.transform.position.y < player2.transform.position.y)
				{
					lowestPlayer = player;
				}
			}	
		}
		else if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().multi)
		{
			lowestPlayer = player;
		}

		if (Vector3.Distance(lowestPlayer.transform.position, transform.position) > detectPlayer)
		{
			rb.simulated = false;
		}
		else
		{
			rb.simulated = true;
		}
	}


	public void FixedUpdate()
    {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (isGrounded)
            {

                if (goingRight)
                {
                    isWalled = Physics2D.OverlapCircle(wallCheckR.position, checkRadius_Wall, whatIsWall);
                    rb.velocity = Vector2.right * speed;
                }
                else
                {
                    isWalled = Physics2D.OverlapCircle(wallCheckL.position, checkRadius_Wall, whatIsWall);
                    rb.velocity = Vector2.left * speed;
                }
            }

            if (isWalled)
            {
                goingRight = !goingRight;
                Flip();
            }
    
    }

    public void Flip()
    {
        if (goingRight)
        {
            wallCheckL.gameObject.SetActive(false);
            wallCheckR.gameObject.SetActive(true);
        }
        else if (!goingRight)
        {
            wallCheckR.gameObject.SetActive(false);
            wallCheckL.gameObject.SetActive(true);
        }
    }
}
