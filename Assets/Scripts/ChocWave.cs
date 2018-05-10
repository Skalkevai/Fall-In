using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		Debug.Log("ChocWave");
		GameObject _chocWave = Instantiate(chocWave,gameObject.transform.position,Quaternion.identity);
		Destroy(_chocWave,2f);
	}
}
