using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject particle;
	public int damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "LaserEnemy" && collision.gameObject.tag != "Wave")
		{
			GameObject _particle = Instantiate(particle,gameObject.transform.position,Quaternion.identity);
			Destroy(gameObject);
			Destroy(_particle,0.5f);
		}
	}
}
