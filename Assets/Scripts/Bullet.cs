using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject particle;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.GetComponent<Enemy>().life--;
			GameObject _particle = Instantiate(particle,gameObject.transform.position,Quaternion.identity);
			Destroy(gameObject);
			Destroy(_particle,0.5f);
		}

		if (collision.transform.parent && collision.gameObject.tag != "Exit")
		{
			if (collision.transform.parent.tag != "Player" && collision.transform.parent.tag != "Player2" && collision.gameObject.tag != "Wave" && collision.tag != "Shield")
			{
				GameObject _particle = Instantiate(particle, gameObject.transform.position, Quaternion.identity);
				Destroy(gameObject);
				Destroy(_particle, 0.5f);
			}
		}
		else if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Exit")
		{
			GameObject _particle = Instantiate(particle,gameObject.transform.position,Quaternion.identity);
			Destroy(gameObject);
			Destroy(_particle,0.5f);
		}
	}
}
