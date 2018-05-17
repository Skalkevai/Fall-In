using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostSprite2 : MonoBehaviour {

	private GameObject player;

	private SpriteRenderer sprite;
	private SpriteRenderer spritePlayer;
	public float timer = 0.2f;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player2");
		sprite = GetComponent<SpriteRenderer>();
		spritePlayer = player.GetComponentInChildren<SpriteRenderer>();


		transform.position = player.transform.position;
		transform.localScale = spritePlayer.transform.localScale;


		sprite.sprite = spritePlayer.sprite;
		//sprite.color = new Vector4(50,50,50,0.2f);
		sprite.color = new Vector4(player.GetComponentInChildren<SpriteRenderer>().color.r, player.GetComponentInChildren<SpriteRenderer>().color.g, player.GetComponentInChildren<SpriteRenderer>().color.b,0.2f);
	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
