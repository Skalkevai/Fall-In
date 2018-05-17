using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;

public class ShootingJoyStick : MonoBehaviour {

	public GameObject player;
	public InputDevice controller;
	private Animator anim;
	public PlayerController playerController;

	private bool isReload;

	private float x;
	private float y;
	public int speed;

	public float fireRate = 15f;
	private float nextTimeToFire = 0f;

	public GameObject bullet;

	void Start ()
	{
		anim = GetComponentInParent<Animator>();
		controller = player.GetComponentInChildren<PlayerController>().controller;
	}

	void Update()
	{
		isReload = GetComponentInParent<PlayerController>().isReload;

		if (player.GetComponentInChildren<PlayerController>().useController)
		{
			x = controller.RightStickX;
			y = controller.RightStickY;
		}

		if (x == 0 || y == 0)
		{
				if (player.GetComponentInChildren<PlayerController>().facingRight)
				{
					x = 1;
				}
				else if (!player.GetComponentInChildren<PlayerController>().facingRight)
				{
					x = -1;
				}
		}

		if (player.GetComponentInChildren<PlayerController>().useController && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
		{
			if (controller.RightTrigger && Time.time >= nextTimeToFire && player.GetComponentInChildren<Player>().ammunition > 0 && !isReload)
			{
				nextTimeToFire = Time.time + 1f / fireRate;
				player.GetComponentInChildren<Player>().ammunition--;
				Shoot();
				anim.SetTrigger("fire");
			}
		}
	}

	void Shoot()
	{
			if (x < 0 && player.GetComponentInChildren<PlayerController>().facingRight)
			{
				player.GetComponentInChildren<PlayerController>().Flip();
			}
			else if (x > 0 && !player.GetComponentInChildren<PlayerController>().facingRight)
			{
				player.GetComponentInChildren<PlayerController>().Flip();
			}
		FindObjectOfType<AudioManager>().Play("PlayerShoot");
		GameObject _bullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x,y).normalized * speed;
	}
}
