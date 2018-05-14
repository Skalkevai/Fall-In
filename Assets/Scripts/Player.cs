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
	public string upgrade;
	public GameObject abilityPicture1;
	public GameObject abilityPicture2;

	[Header("Wave")]
	public GameObject wave;
	public Sprite wavePicture;
	[Header("Shield")]
	public GameObject shield;
	public Sprite shieldPicture;
	[Header("DashMove")]
	public GameObject dash;
	public Sprite dashPicture;
	[Header("WeaponUpgrade")]
	public GameObject weaponUpgrade;
	public Sprite weaponUpgradePicture;
	[Header("JumpUpgrade")]
	public Sprite jumpPicture;
	[Header("Revive")]
	public Sprite revivePicture;

	[Header("Life")]
	public int life;
	public int maxLife;
	public Image[] heart;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	public GameObject reviveEffect;

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

		if (!PlayerPrefs.HasKey("life1"))
		{
			PlayerPrefs.SetInt("life1", 3);
		}
		if (!PlayerPrefs.HasKey("life2"))
		{
			PlayerPrefs.SetInt("life2", 3);
		}

		if (player.tag == "Player")
		{
			maxLife = PlayerPrefs.GetInt("life1");
		}
		else if (player.tag == "Player2")
		{
			maxLife = PlayerPrefs.GetInt("life2");
		}

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
			if (ability1 == "Revive")
			{
				FakeDeath();
				Invoke("Revive",1f);
			}
			else if (ability2 == "Revive")
			{
				FakeDeath();
				Invoke("Revive", 1f);
			}
			else
			{
				Death();
			}
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
			GetComponent<SpriteRenderer>().material.color = Color.red;
		}
		else
		{
			GetComponent<SpriteRenderer>().material.color = new Color32(30,30,30,255);
		}
	}

	public void Revive()
	{
		life = maxLife;

		GameObject _reviveEffect = Instantiate(reviveEffect,transform.position,Quaternion.identity);
		_reviveEffect.transform.SetParent(player.gameObject.transform);
		gameObject.SetActive(true);

		if (ability1 == "Revive")
		{
			if (player.tag == "Player")
			{
				game.player1Ability1 = "";
				ability1 = "";
				ActiveAbility();
				player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}
			else
			{
				game.player2Ability1 = "";
				ability1 = "";
				ActiveAbility();
				player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}
		}
		else if (ability2 == "Revive")
		{
			if (player.tag == "Player")
			{
				game.player1Ability2 = "";
				ability2 = "";
				ActiveAbility();
				player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}
			else
			{
				game.player2Ability2 = "";
				ability2 = "";
				ActiveAbility();
				player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}
		}
	}

	public void FakeDeath()
	{
		gameObject.SetActive(false);
		player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		GameObject _deathEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
		Destroy(_deathEffect, 5f);
	}

	public void ActiveAbility()
	{

		if (player.tag == "Player")
		{
			ability1 = game.player1Ability1;
			ability2 = game.player1Ability2;
		}
		else if(player.tag == "Player2")
		{
			ability1 = game.player2Ability1;
			ability2 = game.player2Ability2;
		}

		switch (ability1)
		{
			case "Wave":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = wavePicture;
				wave.SetActive(true);
				break;
			case "Shield":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = shieldPicture;
				shield.SetActive(true);
				break;
			case "Dash":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = dashPicture;
				dash.SetActive(true);
				break;
			case "Jump":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = jumpPicture;
				GetComponent<PlayerController>().extraJumpValue++;
				break;
			case "Revive":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = revivePicture;
				break;
			case "WeaponUpgrade":
				abilityPicture1.SetActive(true);
				abilityPicture1.GetComponent<Image>().sprite = weaponUpgradePicture;
				weaponUpgrade.SetActive(true);
				break;
			default:
				abilityPicture1.SetActive(false);
				break;
		}

		switch (ability2)
		{
			case "Wave":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = wavePicture;
				wave.SetActive(true);
				break;
			case "Shield":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = shieldPicture;
				shield.SetActive(true);
				break;
			case "Dash":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = dashPicture;
				dash.SetActive(true);
				break;
			case "Jump":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = jumpPicture;
				GetComponent<PlayerController>().extraJumpValue++;
				break;
			case "Revive":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = revivePicture;
				break;
			case "WeaponUpgrade":
				abilityPicture2.SetActive(true);
				abilityPicture2.GetComponent<Image>().sprite = weaponUpgradePicture;
				weaponUpgrade.SetActive(true);
				break;
			default:
				abilityPicture2.SetActive(false);
				break;
		}
	}

	public void ActiveUpgrade()
	{
		if (player.tag == "Player")
		{
			upgrade = game.player1Upgrade;
		}
		else if (player.tag == "Player2")
		{
			upgrade = game.player2Upgrade;
		}

		switch (upgrade)
		{
			case "HeartUpgrade":
				maxLife++;
				life = maxLife;

				if (player.tag == "Player")
				{
					PlayerPrefs.SetInt("life1", maxLife);
				}
				else
				{
					PlayerPrefs.SetInt("life2", maxLife);
				}
				upgrade = "";
				break;

			case "AmmoUpgrade":
				maxAmmo++;
				ammunition = maxAmmo;

				if (player.tag == "Player")
				{
					PlayerPrefs.SetInt("ammo1", maxLife);
				}
				else
				{
					PlayerPrefs.SetInt("ammo2", maxLife);
				}
				upgrade = "";
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
		GameObject _deathEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
		Destroy(_deathEffect, 5f);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().players.Remove(gameObject.transform);
		Destroy(player);
		game.SaveData();
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
