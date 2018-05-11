using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
	public Game game;

	public bool isMission;
	private Mission mission;
	public List<Mission> listMission;

	public string bubbleText;
	public TextMeshPro bubbleTextTMP;

	public void Start()
	{
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

		if (isMission && listMission.Count != 0)
		{
			int r = Random.Range(0,listMission.Count);
			mission = listMission[r];

			bubbleText = "";
			bubbleTextTMP.text = bubbleText;

		}

	}
}
