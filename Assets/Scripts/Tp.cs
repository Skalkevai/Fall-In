using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tp: MonoBehaviour {

	public PlayerController playerController;
	public Game game;

	public string sceneToLoad;

	public void Start()
	{
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.transform.parent.tag == "Player" || collision.transform.parent.tag == "Player2")
		{
			playerController = collision.GetComponent<PlayerController>();


			if (playerController.useController && collision.transform.parent.tag == "Player" || playerController.useController && collision.transform.parent.tag == "Player2")
			{
				playerController = collision.GetComponent<PlayerController>();

				if (playerController.controller.Action3)
				{
					game.SaveData();
					SceneManager.LoadScene(sceneToLoad);
				}

			}
			else
			{
				if (Input.GetKeyDown(KeyCode.E) && collision.transform.parent.tag == "Player" || Input.GetKeyDown(KeyCode.E) && collision.transform.parent.tag == "Player2")
				{
					game.SaveData();
					SceneManager.LoadScene(sceneToLoad);
				}

			}
		}
	}
}
