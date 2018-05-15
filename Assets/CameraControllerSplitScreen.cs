using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSplitScreen : MonoBehaviour {

	public GameObject player;
	public Game game;
	public Vector3 offset;

	public void Start()
	{
		game = Game.FindObjectOfType<Game>();
	}

	public void Update()
	{
		if(!game.multi)
		{
			if(player.tag == "Player2")
			{
				gameObject.SetActive(false);
			}
		}

		gameObject.transform.position = player.transform.position + offset;
	}
}
