using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using InControl;

public class MenuData : MonoBehaviour {

	[Header("ObjectReference")]
	public TextMeshProUGUI versionText;
	public TextMeshProUGUI creditText;
    public Button buttonStart;

	[Header("Option Controller")]
	public Toggle player1KeyboardToggle;
    public Toggle player2KeyboardToggle;
    public Toggle player1GamepadToggle;
    public Toggle player2GamepadToggle;
    public Toggle multiplayerToggle;

	[Header("Option Effect")]
	public Toggle particleEffect;
	public Toggle fogEffect;
	public GameObject fog;
	public GameObject darkParticle;

	[Header("Option Volume")]
	public Slider mainVolume;
	public Slider musicVolume;
	public Slider effectVolume;
	public float mainVolumeFloat;
	public float musicVolumeFloat;
	public float effectVolumeFloat;

	[Header("DataToSave(PlayerPrefs)")]
	public string version;
	public int credit;
	public bool multi;
	public bool player1Gamepad;
	public bool player2Gamepad;
	public int nbController;

	public void Awake()
	{
		LoadData();
		nbController = InputManager.Devices.Count;

		buttonStart.Select();
		version = "V." + Application.version;
		versionText.text = version;

		if (multi == true)
		{
			multiplayerToggle.isOn = true;
		}
		else
		{
			multiplayerToggle.isOn = false;
			player2GamepadToggle.isOn = false;
		}

		if (player1Gamepad == true)
		{
			player1GamepadToggle.isOn = true;
		}
		else
		{
			player1KeyboardToggle.isOn = true;
		}

		if (player2Gamepad == true)
		{
			player2GamepadToggle.isOn = true;
		}
		else
		{
			player2KeyboardToggle.isOn = true;
		}

		if (fogEffect.isOn == true)
		{
			fog.SetActive(true);
		}
		else
		{
			fog.SetActive(false);
		}

		if (particleEffect.isOn == true)
		{
			darkParticle.SetActive(true);
		}
		else
		{
			darkParticle.SetActive(false);
		}

		mainVolume.value = mainVolumeFloat;
		musicVolume.value = musicVolumeFloat;
		effectVolume.value = effectVolumeFloat;
	}

	public void Update()
	{
		nbController = InputManager.Devices.Count;

		if (nbController == 0)
		{
			player1GamepadToggle.isOn = false;
			player1KeyboardToggle.isOn = true;
			player1GamepadToggle.isOn = false;
			player2KeyboardToggle.isOn = false;
			multiplayerToggle.isOn = false;
		}

		else if (nbController == 1)
		{
			if (player2GamepadToggle.isOn == true && player1GamepadToggle.isOn == true)
			{
				player2KeyboardToggle.isOn = true;
			}
			else if (player1GamepadToggle.isOn == true)
			{
				player2GamepadToggle.isOn = false;
			}
			else if (player2GamepadToggle.isOn == true)
			{
				player1GamepadToggle.isOn = false;
			}
		}

		if (player1KeyboardToggle.isOn == true && player2KeyboardToggle.isOn == true)
		{
			player2KeyboardToggle.isOn = false;
			player2GamepadToggle.isOn = true;
		}

		if (fogEffect.isOn == true)
		{
			fog.SetActive(true);
		}
		else
		{
			fog.SetActive(false);
		}

		if (particleEffect.isOn == true)
		{
			darkParticle.SetActive(true);
		}
		else
		{
			darkParticle.SetActive(false);
		}
	}

	public void LateUpdate()
	{
		mainVolumeFloat = mainVolume.value;
		musicVolumeFloat = musicVolume.value;
		effectVolumeFloat = effectVolume.value;
	}

	public void LoadScene()
    {
        SaveData();
        SceneManager.LoadScene("Lobby");
            
    }

    public void CloseGame()
    {
        SaveData();
        Application.Quit();
    }

	public void SaveData()
	{
		multi = multiplayerToggle.isOn;
		player1Gamepad = player1GamepadToggle.isOn;
		player2Gamepad = player2GamepadToggle.isOn;

		if (multi)
		{
			PlayerPrefs.SetString("Multi", "True");
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

		if (fogEffect.isOn == true)
		{
			PlayerPrefs.SetString("fog", "True");
		}
		else
		{
			PlayerPrefs.SetString("fog", "False");
		}

		if (particleEffect.isOn == true)
		{
			PlayerPrefs.SetString("particle", "True");
		}
		else
		{
			PlayerPrefs.SetString("particle", "False");
		}

		PlayerPrefs.SetFloat("mainVolume",mainVolume.value);
		PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
		PlayerPrefs.SetFloat("effectVolume", effectVolume.value);


	}

	public void LoadData()
	{
		if (PlayerPrefs.HasKey("Multi"))
		{
			if (PlayerPrefs.GetString("Multi") == "True")
			{
				multi = true;
			}
			else if (PlayerPrefs.GetString("Multi") == "False")
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

		if (PlayerPrefs.GetString("fog") == "True")
		{
			fogEffect.isOn = true;
		}
		else
		{
			fogEffect.isOn = false;
		}

		if (PlayerPrefs.GetString("particle") == "True")
		{
			particleEffect.isOn = true;
		}
		else
		{
			particleEffect.isOn = false;
		}

		mainVolumeFloat = PlayerPrefs.GetFloat("mainVolume");
		musicVolumeFloat = PlayerPrefs.GetFloat("musicVolume");
		effectVolumeFloat = PlayerPrefs.GetFloat("effectVolume");

	}
}
