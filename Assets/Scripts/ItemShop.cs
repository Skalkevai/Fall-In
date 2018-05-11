using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour {

	private Game game;
	public new string name;
	public int cost;
	private bool alreadyGet;

	private void OnTriggerStay2D(Collider2D collision)
	{
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

		if (cost > game.credit)
		{
			Debug.Log("You don't have enough credit");
		}

		else
		{
			if (!(collision.GetComponentInChildren<Player>().ability1 == name || collision.GetComponentInChildren<Player>().ability2 == name))
			{
				if (collision.GetComponentInChildren<PlayerController>().useController && collision.GetComponentInChildren<PlayerController>().controller.Action3.WasReleased && !alreadyGet)
				{
					if (collision.GetComponentInChildren<Player>().player.tag == "Player")
					{
						if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability1 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability1 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
						else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
					}

					else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
					{
						if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
						else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
					}
				}

				else if (!collision.GetComponentInChildren<PlayerController>().useController && Input.GetKeyDown(KeyCode.E) && !alreadyGet)
				{
					if (collision.GetComponentInChildren<Player>().player.tag == "Player")
					{
						if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability1 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability1 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
						else if(GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
					}
					else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
					{
						if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
						else if(GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 == "")
						{
							GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 = name;
							alreadyGet = true;
							Destroy(gameObject);
							game.credit -= cost;
							collision.GetComponentInChildren<Player>().ActiveAbility();
						}
					}
				}
			}
			else
			{
				Debug.Log("You already have :" + name);
			}
		}
	}
}
