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
	public SpriteRenderer bubbleRender;
	public Animator showBubble;

	public void Start()
	{
		showBubble = GetComponent<Animator>();
		bubbleRender = GetComponent<SpriteRenderer>();
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

		if (isMission && listMission.Count != 0)
		{
			int r = Random.Range(0,listMission.Count);
			mission = listMission[r];

			bubbleText += "--- "+mission.missionName+ " ---\n";
			bubbleText += mission.description+ "\n";
			bubbleText += mission.reward+ "$\n";
			bubbleTextTMP.text = bubbleText;

		}
		bubbleRender.enabled = false;
		bubbleTextTMP.enabled = false;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		game.missionLvl = mission.missionLvl;
		Debug.Log("Your mission is now "+ mission.missionName);

		showBubble.enabled = true;
		bubbleRender.enabled = true;
		bubbleTextTMP.enabled = true;
		showBubble.Play("Bubble", -1, 0f);
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		showBubble.enabled = false;
		bubbleRender.enabled = false;
		bubbleTextTMP.enabled = false;
	}

}
