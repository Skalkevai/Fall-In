using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour {

	private Camera camera;
	public GameObject player;
	private Animator anim;

	public int speed;

	public bool isReload;

	private Vector2 direction;
	private Vector2 target;
	private Vector2 myPos;

	public GameObject bullet;
	public float fireRate = 15f;
	private float nextTimeToFire = 0f;

	private void Start()
	{
		anim = GetComponentInParent<Animator>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	public void Update()
	{
		isReload = GetComponentInParent<PlayerController>().isReload;

		myPos = new Vector2(player.transform.position.x, player.transform.position.y);
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && player.GetComponentInChildren<Player>().ammunition > 0 && !isReload && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			myPos = new Vector2(player.transform.position.x, player.transform.position.y);
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			player.GetComponentInChildren<Player>().ammunition--;
			Shoot();
			anim.SetTrigger("fire");
		}
	}

	void Shoot()
	{
		direction = target - myPos;
		direction.Normalize();

		if (direction.x < 0 && player.GetComponentInChildren<PlayerController>().facingRight)
		{
			player.GetComponentInChildren<PlayerController>().Flip();
		}
		else if (direction.x > 0 && !player.GetComponentInChildren<PlayerController>().facingRight)
		{
			player.GetComponentInChildren<PlayerController>().Flip();
		}

		FindObjectOfType<AudioManager>().Play("PlayerShoot");
		GameObject _bullet = Instantiate(bullet,myPos,Quaternion.identity);
		_bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
