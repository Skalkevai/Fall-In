using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour {

	public new string name;
	private bool alreadyGet;

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.GetComponentInChildren<Player>().ability1 != name && collision.GetComponentInChildren<Player>().ability1 != name)
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
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
                    }
                }

                else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
                {
                    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 == "")
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
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
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player1Ability2 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
                    }
                }
                else if (collision.GetComponentInChildren<Player>().player.tag == "Player2")
                {
                    if (GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 == "")
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability1 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().player2Ability2 = name;
                        alreadyGet = true;
                        Destroy(gameObject);
                    }
                }
            }
            collision.GetComponentInChildren<Player>().ActiveAbility();
            Debug.Log(name);
        }
        else
        {
            Debug.Log("You already have :"+name);
        }
	}
}
