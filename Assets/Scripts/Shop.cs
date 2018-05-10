using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public GameObject counter;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	public List<GameObject> itemList;

	// Use this for initialization
	void Start ()
	{
		itemList = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().items;

		int r = Random.Range(0,itemList.Count);

		GameObject itemRandom = Instantiate(itemList[r],counter.transform.position,Quaternion.identity);
		itemRandom.transform.SetParent(counter.transform);
		
	}
	
}
