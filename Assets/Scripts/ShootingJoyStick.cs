using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;

public class ShootingJoyStick : MonoBehaviour {

	public GameObject player;
	public InputDevice controller;

	private bool isReload;

	private float x;
	private float y;
	public int speed;

	public float fireRate = 15f;
	private float nextTimeToFire = 0f;

	public GameObject bullet;

	void Start ()
	{
		controller = player.GetComponent<PlayerController>().controller;
	}

	void Update()
	{
		isReload = GetComponentInParent<PlayerController>().isReload;

		if (player.GetComponent<PlayerController>().useController)
		{
			x = controller.RightStickX;
			y = controller.RightStickY;
		}

		if (x == 0 || y == 0)
		{
				if (player.GetComponent<PlayerController>().facingRight)
				{
					x = 1;
				}
				else if (!player.GetComponent<PlayerController>().facingRight)
				{
					x = -1;
				}
		}

		if (player.GetComponent<PlayerController>().useController && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
		{
			if (controller.RightTrigger && Time.time >= nextTimeToFire && player.GetComponent<Player>().ammunition > 0 && !isReload)
			{
				nextTimeToFire = Time.time + 1f / fireRate;
				player.GetComponent<Player>().ammunition--;
				Shoot();
			}
		}
	}

	void Shoot()
	{
			if (x < 0 && player.GetComponent<PlayerController>().facingRight)
			{
				player.GetComponent<PlayerController>().Flip();
			}
			else if (x > 0 && !player.GetComponent<PlayerController>().facingRight)
			{
				player.GetComponent<PlayerController>().Flip();
			}
		FindObjectOfType<AudioManager>().Play("PlayerShoot");
		GameObject _bullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x,y).normalized * speed;
	}
}
