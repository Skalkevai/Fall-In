using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_MonsterWall : MonoBehaviour {

	public bool flip;
	public float delayBetweenShot;
	public bool isRight;

	public int fireRate;
	public GameObject laser;
	public Transform eye;
	public Vector3 direction;
	public int speed;

	// Use this for initialization
	void Start ()
	{

		if (transform.position.x == 5)
		{
			Flip();
		}

		InvokeRepeating("Laser", 1f, delayBetweenShot);
		InvokeRepeating("Laser", 1.2f, delayBetweenShot);
		InvokeRepeating("Laser", 1.4f, delayBetweenShot);
	}

	public void Update()
	{
		if (isRight)
		{
			direction = new Vector3(-1, 0, 0);
		}
		else
		{
			direction = new Vector3(1, 0, 0);
		}
	}

	public void Laser()
	{
		if(gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
		{
			FindObjectOfType<AudioManager>().Play("EnemyShoot");
			GameObject _bullet = Instantiate(laser, eye.position, Quaternion.identity);
			_bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
	}

	public void Flip()
	{
		if (!flip)
		{
			isRight = true;
			Vector3 Scaler = transform.localScale;
			Scaler.x *= -1;
			transform.localScale = Scaler;
			flip = true;
		}
	}
}
