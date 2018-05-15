using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.1f;
	public float slowdownLenght = 2f;

	public AudioManager audioManager;

	public void Start()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager>();
	}

	public void DoSlownMotion()
	{
		Time.timeScale = slowdownFactor;

		foreach (Sound s in audioManager.sounds)
		{
			s.pitch = slowdownFactor;
		}

		audioManager.GetComponent<AudioSource>().pitch = slowdownFactor;
	}

	public void ReturnNormal()
	{
		Time.timeScale = 1f;
	}
}
