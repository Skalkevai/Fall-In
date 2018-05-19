using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	private int min_X = -4;
	private int max_X = 4;
	public int max_Y;

	public int betweenPlatform;

	private GameObject player;
	private GameObject player2;
	private GameObject spawn;

	public Game game;

	public List<GameObject> listPlatform;

	public List<GameObject> listFloorMonster;
	public List<GameObject> listWallMonster;
	public List<GameObject> listFlyingMonster;
	public GameObject torchL;
	public GameObject torchR;

	public GameObject map;
	public GameObject enemy;

	public GameObject platformEnd;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		spawn = GameObject.FindGameObjectWithTag("SpawnPoint");

		player.transform.position = spawn.transform.position;

		if (game.multi)
		{
			player2.transform.position = spawn.transform.position + new Vector3(1, 0, 0);
		}

		if (betweenPlatform < 2)
		{
			betweenPlatform = 2;
		}
		int y = -2;

		while (y > -max_Y)
		{
			int r = Random.Range(0, listPlatform.Count);
			int x = Random.Range(min_X, max_X + 1);

			GameObject platform = Instantiate(listPlatform[r], new Vector3(x, y, 0), Quaternion.identity);
			platform.transform.SetParent(map.transform);
		
			//Spawn Torch
			if (y%2 == 0)
			{
				
					GameObject _torchL = Instantiate(torchL, new Vector3(-4.5f , y + 1, 0), Quaternion.identity);
					_torchL.transform.SetParent(map.transform);

					GameObject _torchR = Instantiate(torchR, new Vector3(4.5f , y + 1, 0), Quaternion.identity);
					_torchR.transform.SetParent(map.transform);
			}

			//Spawn BigBlob & Blob
			r = Random.Range(0, listFloorMonster.Count);
			int spawnChance = Random.Range(0, 3);
			if (spawnChance == 1)
			{
				GameObject monster = listFloorMonster[r];

				if (y > -max_Y / 2)
				{
					while (monster.GetComponent<Enemy>().name == "Big Blob")
					{
						r = Random.Range(0, listFloorMonster.Count);
						monster = listFloorMonster[r];
					}
				}

				GameObject _monster = Instantiate(listFloorMonster[r], new Vector3(x, y + 1, 0), Quaternion.identity);
				_monster.transform.SetParent(enemy.transform);
			}


			//Spawn WallMonster
			spawnChance = Random.Range(0, 5);

			if (spawnChance == 1)
			{
				r = Random.Range(0, listWallMonster.Count);
				GameObject monster = listWallMonster[r];

				int side = Random.Range(0, 2);

				if (side == 1)
				{
					GameObject _monster = Instantiate(monster, new Vector3(-5 , y + 2, 0), Quaternion.identity);
					_monster.transform.SetParent(enemy.transform);
				}
				else if (side == 0)
				{
					GameObject _monster = Instantiate(monster, new Vector3(5 , y + 2, 0), Quaternion.identity);
					_monster.transform.SetParent(enemy.transform);
				}
			}
			y -= betweenPlatform;
		}
		GameObject _platformEnd = Instantiate(platformEnd, new Vector3(0, y, 0), Quaternion.identity);
		_platformEnd.transform.SetParent(map.transform);

	}
}
