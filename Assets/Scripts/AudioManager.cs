using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	private void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

	private void Update()
	{
		if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>())
		{
			AudioListener.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().mainVolumeFloat / 100;
		}
		else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>())
		{
			AudioListener.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>().mainVolumeFloat / 100;
		}

		if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>())
		{
			GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().musicVolumeFloat / 100;
		}
		else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>())
		{
			GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>().musicVolumeFloat / 100;
		}

		foreach (Sound s in sounds)
		{

			if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>())
			{
				s.source.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().effectVolumeFloat / 100;
			}
			else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>())
			{
				s.source.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuData>().effectVolumeFloat / 100;
			}
		}
	}

	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}


}
