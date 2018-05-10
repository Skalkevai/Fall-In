using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChocWave : MonoBehaviour {

	public GameObject chocWave;
	public int damage;
	public float range;

	public float countdownTime;
	private float countdownTimeDefault = 15f;
	private bool countdown;

	public PlayerController playerController;

	private void Start()
	{
		countdownTime = countdownTimeDefault;
	}

	public void Update()
	{
		if (countdown && playerController.ability1.GetComponent<Image>().sprite.name == "Wave")
		{
			playerController.ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (countdown && playerController.ability2.GetComponent<Image>().sprite.name == "Wave")
		{
			playerController.ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (!countdown && playerController.ability1.GetComponent<Image>().sprite.name == "Wave")
		{
			playerController.ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
		else if (!countdown && playerController.ability2.GetComponent<Image>().sprite.name == "Wave")
		{
			playerController.ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}

		if (playerController.useController)
		{
			if (playerController.controller.Action4.WasPressed && !countdown)
			{
				Choc();
				countdown = true;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.F) && !countdown)
			{
				Choc();
				countdown = true;
			}
		}

		if (countdownTime > 0 && countdown)
		{
			countdownTime -= Time.deltaTime;
		}
		else if (countdownTime <= 0)
		{
			countdown = false;
			countdownTime = countdownTimeDefault;
		}
	}

	public void Choc()
	{
		GameObject _chocWave = Instantiate(chocWave,gameObject.transform.position,Quaternion.identity);
		Destroy(_chocWave,2f);
	}
}
