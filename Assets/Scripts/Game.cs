using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;
using TMPro;
using System;

public class Game : MonoBehaviour {

	[Header("DeathScreen")]
	public GameObject deathScreen;
	public TimeManager timeManager;
	public GameObject canvas;
	public bool alreadyDead;

	[Header("MultiPlayer UI")]
	public GameObject life2Player;
	public GameObject ammo2Player;
	public CameraController camera;
	public GameObject player2;
	public GameObject abilityPlayer2;
	public TextMeshProUGUI creditText;

	[Header("SaveData")]
	public int credit;
	public List<GameObject> items;
	public string player1Ability1;
	public string player1Upgrade;
	public string player1Ability2;
	public string player2Ability1;
	public string player2Ability2;
	public string player2Upgrade;

	public GameObject fog;
	public GameObject darkParticle;
	public float mainVolumeFloat;
	public float musicVolumeFloat;
	public float effectVolumeFloat;

	[Header("Camera")]
	public GameObject onePlayer;
	public GameObject blackSeperator;
	public GameObject cameraPlayer1;
	public GameObject cameraPlayer2;

	[Header("Mission")]
	public string missionName;
	public string missionLvl;
	public int missionReward;
	public string missionDescription;
	public bool missionIsAchieved;

	[Header("Controller")]
	public InputDevice controller1;
	public InputDevice controller2;
	public PlayerController playerController1;
	public PlayerController playerController2;

	[Header("MultiPlayer Gestion")]
	public bool multi;
	public bool player1Gamepad;
	public bool player2Gamepad;
	public int nbController;

	private void Update()
	{
		if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
		{

			if (camera.players.Count == 0 && !alreadyDead)
			{
				timeManager.DoSlownMotion();
				GameObject _deathScreen = Instantiate(deathScreen,canvas.transform.position,Quaternion.identity);
				_deathScreen.transform.SetParent(canvas.transform);
				alreadyDead = true;
			}
		}
		creditText.text = credit + "$";
	}

	private void Awake()
	{
		Time.timeScale = 1f;
		LoadData();

		if (!multi)
		{
			camera.players.Remove(camera.players[1]);

			life2Player.SetActive(false);
			ammo2Player.SetActive(false);
			abilityPlayer2.SetActive(false);
			player2.SetActive(false);

			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lobby"))
			{
				cameraPlayer1.SetActive(false);
				cameraPlayer2.SetActive(false);
				blackSeperator.SetActive(false);
			}
		}
		else
		{
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lobby"))
			{
				onePlayer.SetActive(false);
			}
		}

		nbController = InputManager.Devices.Count;


		if (player1Gamepad && !player2Gamepad)
		{
			playerController1.controller = InputManager.Devices[0];
			playerController1.useController = true;
			playerController2.useController = false;
		}
		else if (player2Gamepad && !player1Gamepad)
		{
			if (multi)
			{
				playerController2.controller = InputManager.Devices[0];
			}
			playerController2.useController = true;
			playerController1.useController = false;
		}
		else if (player1Gamepad && player2Gamepad)
		{
			playerController1.controller = InputManager.Devices[0];
			playerController1.useController = true;

			if (multi)
			{
				playerController2.controller = InputManager.Devices[1];
				playerController2.useController = true;
			
			}
		
		}

		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
		{
			if (player1Gamepad)
			{
				playerController1.gameObject.GetComponentInChildren<ShootingJoyStick>().enabled = true;
				playerController1.gameObject.GetComponentInChildren<Shooting>().enabled = false;
			}
			else
			{
				playerController1.gameObject.GetComponentInChildren<ShootingJoyStick>().enabled = false;
				playerController1.gameObject.GetComponentInChildren<Shooting>().enabled = true;
			}

			if (player2Gamepad)
			{
				playerController2.gameObject.GetComponentInChildren<ShootingJoyStick>().enabled = true;
				playerController2.gameObject.GetComponentInChildren<Shooting>().enabled = false;
			}
			else
			{
				playerController2.gameObject.GetComponentInChildren<ShootingJoyStick>().enabled = false;
				playerController2.gameObject.GetComponentInChildren<Shooting>().enabled = true;
			}
		}
	}


	public void SaveData()
	{
		PlayerPrefs.SetInt("Credit",credit);

		if (multi)
		{
			PlayerPrefs.SetString("Multi","True");
		}
		else
		{
			PlayerPrefs.SetString("Multi", "False");
		}
		if (player1Gamepad)
		{
			PlayerPrefs.SetString("player1Gamepad", "True");
		}
		else
		{
			PlayerPrefs.SetString("player1Gamepad", "False");
		}
		if (player2Gamepad)
		{
			PlayerPrefs.SetString("player2Gamepad", "True");
		}
		else
		{
			PlayerPrefs.SetString("player2Gamepad", "False");
		}

		PlayerPrefs.SetString("player1Ability1", player1Ability1);
		PlayerPrefs.SetString("player1Ability2", player1Ability2);
		PlayerPrefs.SetString("player2Ability1", player2Ability1);
		PlayerPrefs.SetString("player2Ability2", player2Ability2);

		PlayerPrefs.SetString("missionName",missionName);
		PlayerPrefs.SetString("missionLvl",missionLvl);
		PlayerPrefs.SetInt("reward",missionReward);
		PlayerPrefs.SetString("description",missionDescription);

		if (missionIsAchieved)
		{
			PlayerPrefs.SetString("isAchieved", "True");
		}
		else
		{
			PlayerPrefs.SetString("isAchieved", "False");
		}
	}

	private void LoadData()
	{
		if (PlayerPrefs.HasKey("Credit"))
		{
			credit = PlayerPrefs.GetInt("Credit");
		}
		if (PlayerPrefs.HasKey("Multi"))
		{
			if (PlayerPrefs.GetString("Multi") == "True")
			{
				multi = true;
			}
			else if(PlayerPrefs.GetString("Multi") == "False")
			{
				multi = false;
			}
		}
		if (PlayerPrefs.HasKey("player1Gamepad"))
		{
			if (PlayerPrefs.GetString("player1Gamepad") == "True")
			{
				player1Gamepad = true;
			}
			else if (PlayerPrefs.GetString("player1Gamepad") == "False")
			{
				player1Gamepad = false;
			}
		}
		if (PlayerPrefs.HasKey("player2Gamepad"))
		{
			if (PlayerPrefs.GetString("player2Gamepad") == "True")
			{
				player2Gamepad = true;
			}
			else if (PlayerPrefs.GetString("player2Gamepad") == "False")
			{
				player2Gamepad = false;
			}
		}

		player1Ability1 = PlayerPrefs.GetString("player1Ability1");
		player1Ability2 = PlayerPrefs.GetString("player1Ability2");
		player2Ability1 = PlayerPrefs.GetString("player2Ability1");
		player2Ability2 = PlayerPrefs.GetString("player2Ability2");

		if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Shop")&& SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Bar"))
		{
			if (PlayerPrefs.GetString("fog") == "True")
			{
				fog.SetActive(true);
			}
			else
			{
				fog.SetActive(false);
			}

			if (PlayerPrefs.GetString("particle") == "True")
			{
				darkParticle.SetActive(true);
			}
			else
			{
				darkParticle.SetActive(false);
			}

		}
		mainVolumeFloat = PlayerPrefs.GetFloat("mainVolume");
		musicVolumeFloat = PlayerPrefs.GetFloat("musicVolume");
		effectVolumeFloat = PlayerPrefs.GetFloat("effectVolume");

		missionName = PlayerPrefs.GetString("missionName");
		missionLvl = PlayerPrefs.GetString("missionLvl");
		missionReward = PlayerPrefs.GetInt("reward");
		missionDescription = PlayerPrefs.GetString("description");

		if (PlayerPrefs.GetString("isAchieved") == "True")
		{
			missionIsAchieved = true;
		}
		else
		{
			missionIsAchieved = false;
		}
	}
}
