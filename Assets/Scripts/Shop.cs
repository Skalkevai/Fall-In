using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour {

	public GameObject counter;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	public TextMeshPro cost1;
	public TextMeshPro cost2;
	public TextMeshPro cost3;
	public TextMeshPro onSale;

	public List<GameObject> itemList;

	// Use this for initialization
	void Start ()
	{
		itemList = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>().items;

		int r = Random.Range(0,itemList.Count);

		GameObject itemRandom = Instantiate(itemList[r],counter.transform.position,Quaternion.identity);
		itemRandom.transform.SetParent(counter.transform);
		itemRandom.GetComponent<ItemShop>().cost /= 2;
		itemList.RemoveAt(r);
		onSale.text = itemRandom.GetComponent<ItemShop>().cost + "$";

		if (itemList.Count != 0)
		{
			r = Random.Range(0, itemList.Count);

			itemRandom = Instantiate(itemList[r], item1.transform.position, Quaternion.identity);
			itemRandom.transform.SetParent(item1.transform);
			itemList.RemoveAt(r);
			cost1.text = itemRandom.GetComponent<ItemShop>().cost+"$";
		}

		if (itemList.Count != 0)
		{
			r = Random.Range(0, itemList.Count);

			itemRandom = Instantiate(itemList[r], item2.transform.position, Quaternion.identity);
			itemRandom.transform.SetParent(item2.transform);
			itemList.RemoveAt(r);
			cost2.text = itemRandom.GetComponent<ItemShop>().cost + "$";
		}

		if (itemList.Count != 0)
		{
			r = Random.Range(0, itemList.Count);

			itemRandom = Instantiate(itemList[r], item3.transform.position, Quaternion.identity);
			itemRandom.transform.SetParent(item3.transform);
			itemList.RemoveAt(r);
			cost3.text = itemRandom.GetComponent<ItemShop>().cost + "$";
		}

	}
	
}
