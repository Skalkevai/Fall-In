using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public new string name; 
	public GameObject effect;
	public int life;
	public int attack;
	public int gain;

	public void Start()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies)
		{
			if (enemy.GetComponent<BoxCollider2D>())
			{
				Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
			}
			
		}
	}

	private void Update()
	{
		if (life <= 0)
		{
			GameObject _particle = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
			Destroy(_particle, 1f);
			FindObjectOfType<Game>().credit += gain;
		}
	}
}
