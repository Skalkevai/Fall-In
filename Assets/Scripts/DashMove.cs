using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DashMove : MonoBehaviour {

	public PlayerController playerController;
	public Rigidbody2D rb;
	public Player player;

	public Vector3 dashDistance;
	public GameObject startEffect;
	public GameObject endEffect;

	public float countdownTime;
	private float countdownTimeDefault = 5f;
	public bool countdown;

	public void Start()
	{
		countdownTime = countdownTimeDefault;
		rb = GetComponentInParent<Rigidbody2D>();
	}

	private void Update()
	{
		if (countdownTime > 0 && countdown)
		{
			countdownTime -= Time.deltaTime;
		}
		else if (countdownTime <= 0)
		{
			countdown = false;
			countdownTime = countdownTimeDefault;
		}

		if (countdown && playerController.ability1.GetComponent<Image>().sprite.name == "Dash")
		{
			playerController.ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (countdown && playerController.ability2.GetComponent<Image>().sprite.name == "Dash")
		{
			playerController.ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (!countdown && playerController.ability1.GetComponent<Image>().sprite.name == "Dash")
		{
			playerController.ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
		else if (!countdown && playerController.ability2.GetComponent<Image>().sprite.name == "Dash")
		{
			playerController.ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}

		if (playerController.useController)
		{
			if (playerController.controller.Action2 && !countdown)
			{
				if(playerController.facingRight)
				{
					if (rb.transform.position.x + dashDistance.x > 5 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect,rb.transform.position,Quaternion.identity);
						rb.transform.position = new Vector3(5, rb.transform.position.y, 0);
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
					else
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position += dashDistance;
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
					
				}
				else if (!playerController.facingRight)
				{
					if (rb.transform.position.x - dashDistance.x < -5 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position = new Vector3(-5, rb.transform.position.y, 0);
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
					else
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position -= dashDistance;
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
				}

			}
		}
		else if(!playerController.useController)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift) && !countdown)
			{
				if (playerController.facingRight)
				{
					if (rb.transform.position.x + dashDistance.x > 5 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position = new Vector3(5, rb.transform.position.y, 0);
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
					else
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);						
						rb.transform.position += dashDistance;
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
				}
				else if (!playerController.facingRight)
				{
					if (rb.transform.position.x - dashDistance.x < -5 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position = new Vector3(-5, rb.transform.position.y, 0);
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
					else
					{
						countdown = true;
						GameObject _startEffect = Instantiate(startEffect, rb.transform.position, Quaternion.identity);
						rb.transform.position -= dashDistance;
						GameObject _endEffect = Instantiate(endEffect, rb.transform.position, Quaternion.identity);
					}
				}
			}
		}
	}

}
