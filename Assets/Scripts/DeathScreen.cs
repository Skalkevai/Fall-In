using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	public TextMeshProUGUI totalCredit;
	private Game game;

	void Start ()
	{
		game = GameObject.FindObjectOfType<Game>();
		game.credit -= 50;

		if (game.credit < 0)
		{
			game.credit = 0;
		}

		totalCredit.text = "Total Credit : "+game.credit + "$";
	}


	public void ReturnLobby()
	{
		game.SaveData();
		SceneManager.LoadScene("Lobby");
	}
}
