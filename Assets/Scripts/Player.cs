using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject player;

	[Header("Ability")]
	public string ability1;
	public string ability2;

	public GameObject wave;
	public GameObject shield;
	public GameObject dash;
	public GameObject teleport;
	public GameObject heartUpgrade;
	public GameObject ammoUpgrade;
	public GameObject weaponUpgrade;
	public GameObject jump;
	public GameObject revive;

	[Header("Life")]
	public int life;
	public int maxLife;
	public Image[] heart;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	[Header("Ammunition")]
	public int ammunition;
	public int maxAmmo;
	public Image[] ammo;
	public Sprite fullAmmo;
	public Sprite emptyAmmo;

	[Header("Divers")]
	public string death;
	public float timeInvincible;
	public float invincibleEffect = 2f;
	public bool invincible;
	private bool isReload;
	public Game game;
	public GameObject hitEffect;
	public GameObject deathEffect;
	public CameraShake cameraShake;
	public CameraController camera;

	// Use this for initialization
	void Start()
	{
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
		camera = cameraShake.GetComponent<CameraController>();

		ActiveAbility();
		
		life = maxLife;
		ammunition = maxAmmo;
	}

	public void Update()
	{
		//current life can't go more than the maxlife
		if (life > maxLife)
		{
			life = maxLife;
		}
			//Show the picture of number of heart
			for (int i = 0; i < heart.Length; i++)
			{
				if (i < life)
				{
					heart[i].sprite = fullHeart;
				}
				else
				{
					heart[i].sprite = emptyHeart;
				}

				if (i < maxLife)
				{
					heart[i].enabled = true;
				}
				else
				{
					heart[i].enabled = false;
				}
			}

			for (int i = 0; i < ammo.Length; i++)
			{
				if (i < ammunition)
				{
					ammo[i].sprite = fullAmmo;
				}
				else
				{
					ammo[i].sprite = emptyAmmo;
				}

				if (i < maxAmmo)
				{
					ammo[i].enabled = true;
				}
				else
				{
					ammo[i].enabled = false;
				}
			}

		//Detect if Dead
		if (life <= 0)
		{
			Death();
		}

        //Detect if need to reload
        if (ammunition <= 0)
        {
            GetComponent<PlayerController>().isReload = true;
            Reload();
        }

        //The player gain invincibility during a short period
        if (invincible && timeInvincible > 0)
		{
			timeInvincible -= Time.deltaTime;
		}
		else if( timeInvincible <= 0)
		{
			invincible = false;
			timeInvincible = invincibleEffect;
		}

		//The player become half transparent
		if (invincible)
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
		}

	}

	public void ActiveAbility()
	{

		if (player.tag == "Player")
		{
			ability1 = game.player1Ability1;
			ability2 = game.player1Ability2;
		}
		else
		{
			ability1 = game.player2Ability1;
			ability2 = game.player2Ability2;
		}


		switch (ability1)
		{
			case "Wave":
				wave.SetActive(true);
				break;
			case "Shield":
				wave.SetActive(true);
				break;
			case "Dash":
				break;
			case "Teleport":
				wave.SetActive(true);
				break;
			case "Jump":
				wave.SetActive(true);
				break;
			case "Revive":
				wave.SetActive(true);
				break;
			case "HeartUpgrade":
				wave.SetActive(true);
				break;
			case "AmmoUpgrade":
				wave.SetActive(true);
				break;
			case "WeaponUpgrade":
				wave.SetActive(true);
				break;
		}

		switch (ability2)
		{
			case "Wave":
				wave.SetActive(true);
				break;
			case "Shield":
				wave.SetActive(true);
				break;
			case "Dash":
				break;
			case "Teleport":
				wave.SetActive(true);
				break;
			case "Jump":
				wave.SetActive(true);
				break;
			case "Revive":
				wave.SetActive(true);
				break;
			case "HeartUpgrade":
				wave.SetActive(true);
				break;
			case "AmmoUpgrade":
				wave.SetActive(true);
				break;
			case "WeaponUpgrade":
				wave.SetActive(true);
				break;
		}
	}

	public void Reload()
	{
		InvokeRepeating("Load1Ammo",0f,0.2f);
	}

	public void Load1Ammo()
	{
		if (ammunition == maxAmmo)
		{
			gameObject.GetComponent<PlayerController>().isReload = false;
			CancelInvoke();
		}
		else
		{
			ammunition++;
		}
		
	}

	public void Death()
	{
		game.SaveData();
		GameObject _deathEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
		Destroy(_deathEffect, 5f);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().players.Remove(gameObject.transform);
		Destroy(player);
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy" && !invincible)
		{
			death = collision.GetComponent<Enemy>().name;
			FindObjectOfType<AudioManager>().Play("PlayerHurt");

			life -= collision.GetComponent<Enemy>().attack;
			invincible = true;

			GameObject blood = Instantiate(hitEffect,gameObject.transform.position,Quaternion.identity);
			Destroy(blood,5f);
			StartCoroutine(cameraShake.Shake(.15f,.4f));
		}

		if (collision.tag == "LaserEnemy" && !invincible)
		{
			death = "Laser";
			FindObjectOfType<AudioManager>().Play("PlayerHurt");

			life -= collision.GetComponent<Laser>().damage;
			invincible = true;

			GameObject blood = Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
			Destroy(blood, 5f);
			StartCoroutine(cameraShake.Shake(.15f, .4f));
		}
	}
}
