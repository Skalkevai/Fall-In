using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


public class PlayerController : MonoBehaviour {

	private Animator anim;

	public InputDevice controller;
	public bool useController;

	public GameObject ability1;
	public GameObject ability2;

	public bool isReload;
	public float timeReload = 0f;

	public float speed;
	public float jumpForce;
	public float moveInput;
	private Rigidbody2D rb;
	public GameObject ghost;

	[HideInInspector]
	public bool facingRight = true;

	public bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;


	public bool isWalled;
	public Transform wallCheckL;
	public Transform wallCheckR;
	public float checkRadius_Wall;
	public LayerMask whatIsWall;

	public int extraJump;
	public int extraJumpValue;


	private void Start()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		extraJump = extraJumpValue;
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		GameObject _ghost = Instantiate(ghost,transform.position,transform.rotation);

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
		isWalled = Physics2D.OverlapCircle(wallCheckL.position, checkRadius_Wall, whatIsWall)|| Physics2D.OverlapCircle(wallCheckR.position, checkRadius_Wall, whatIsWall);

		 if (useController)
		{
			moveInput = controller.LeftStickX;
		}
		else
		{
			moveInput = Input.GetAxis("Horizontal");
		}

		rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);


		if (facingRight == false && moveInput > 0)
		{
			Flip();
		}
		else if(facingRight == true && moveInput < 0)
		{
			Flip();
		}
	}

	private void Update()
	{
		if(isWalled && rb.velocity.y < 0)
		{
			anim.SetBool("isWall", true);
		}
		else
		{
			anim.SetBool("isWall", false);
		}

		if(moveInput != 0)
		{
			anim.SetBool("isRunning", true);
		}
		else if(moveInput == 0)
		{
			anim.SetBool("isRunning", false);
		}

		if (isGrounded == true)
		{
			extraJump = extraJumpValue;
		}

		if (useController)
		{
            if (controller.Action1.WasPressed)
            {
                if (isWalled && moveInput != 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJump = extraJumpValue;
                }
                else if (isGrounded)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJump = extraJumpValue;
                }
                else if (extraJump > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    new WaitForSeconds(0.1f);
                    extraJump--;
                }

				anim.SetTrigger("jump");
            }
		}

		else
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (isWalled && moveInput != 0)
				{
					rb.velocity = Vector2.up * jumpForce;
					extraJump = extraJumpValue;
				}
				else if (isGrounded)
				{
					rb.velocity = Vector2.up * jumpForce;
					extraJump = extraJumpValue;
				}
				else if (extraJump > 0)
				{
					rb.velocity = Vector2.up * jumpForce;
					new WaitForSeconds(0.1f);
					extraJump--;
				}
				anim.SetTrigger("jump");
			}
		}
		
		
	}

	public void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
