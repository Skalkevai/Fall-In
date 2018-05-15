using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{

	private Game game;
	public new string name;
	public int cost;
	private bool alreadyGet;

	private void Start()
	{
		Physics2D.IgnoreLayerCollision(15, 16, true);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{

		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

		if (cost > game.credit)
		{
			Debug.Log("You don't have enough credit");
		}

		else if (collision.GetComponentInChildren<Player>().ability1 != "" && collision.GetComponentInChildren<Player>().ability2 != "" && name != "HeartUpgrade" && name != "AmmoUpgrade")
		{
			Debug.Log("You don't have more space");
		}

		else
		{
			if ((collision.GetComponentInChildren<Player>().ability1 != name && collision.GetComponentInChildren<Player>().ability2 != name) && name != "HeartUpgrade" && name != "AmmoUpgrade")
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
			}

			else if ((name == "HeartUpgrade" || name == "AmmoUpgrade") && collision.GetComponent<Player>().maxAmmo < 20 && collision.GetComponent<Player>().maxLife < 10)
			{
				if (collision.GetComponentInChildren<PlayerController>().useController && collision.GetComponentInChildren<PlayerController>().controller.Action3.WasReleased && !alreadyGet)
				{
					if (collision.GetComponentInChildren<Player>().player.tag == "Player")
					{
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Upgrade = name;
						game.credit -= cost;
						collision.GetComponentInChildren<Player>().ActiveUpgrade();
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Upgrade = "";
						alreadyGet = true;
					}

					else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
					{
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Upgrade = name;
						game.credit -= cost;
						collision.GetComponentInChildren<Player>().ActiveUpgrade();
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Upgrade = "";
						alreadyGet = true;
					}
				}

				else if (!collision.GetComponentInChildren<PlayerController>().useController && Input.GetKeyDown(KeyCode.E) && !alreadyGet)
				{
					if (collision.GetComponentInChildren<Player>().player.tag == "Player")
					{
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Upgrade = name;
						game.credit -= cost;
						collision.GetComponentInChildren<Player>().ActiveUpgrade();
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Upgrade = "";
						alreadyGet = true;
					}
					else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
					{
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Upgrade = name;
						game.credit -= cost;
						collision.GetComponentInChildren<Player>().ActiveUpgrade();
						GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Upgrade = "";
						alreadyGet = true;
					}
				}
			}
			else if(collision.GetComponentInChildren<Player>().maxAmmo == 20 && name == "AmmoUpgrade")
			{
				Debug.Log("You have max your Ammos ");
			}
			else if (collision.GetComponentInChildren<Player>().maxLife == 10 && name == "HeartUpgrade")
			{
				Debug.Log("You have max your lifes ");
			}

			else
			{
				Debug.Log("You already have :" + name);
			}
		}
		Invoke("AlreadyGetOff", 0.2f);
	}


	public void AlreadyGetOff()
	{
		alreadyGet = false;
	}
}
