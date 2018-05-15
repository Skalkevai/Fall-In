using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
	public EdgeCollider2D collider;
	public GameObject shield;
	public GameObject player;

	public float setUseTime;
	public float useTime;

	public float setCooldown;
	public float cooldown;

	private void Update()
	{

		if(player.GetComponentInChildren<PlayerController>().useController)
		{
			if(player.GetComponentInChildren<PlayerController>().controller.RightBumper && cooldown <= 0)
			{
				shield.SetActive(true);
				useTime = setUseTime;
				cooldown = setCooldown;
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.G) && cooldown <= 0)
			{
				shield.SetActive(true);
				useTime = setUseTime;
				cooldown = setCooldown;
			}
		}

		if (cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}

		if (useTime > 0)
		{
			useTime -= Time.deltaTime;
		}
		else if (useTime <= 0)
		{
			shield.SetActive(false);
		}

		Physics2D.IgnoreLayerCollision(15,14);
		Physics2D.IgnoreLayerCollision(15, 9);

		if (player.GetComponentInChildren<PlayerController>().useController)
		{
			float x = player.GetComponentInChildren<PlayerController>().controller.RightStickX;
			float y = player.GetComponentInChildren<PlayerController>().controller.RightStickY;

			Vector2 direction = new Vector2(x, y);//- transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = rotation;
		}
		else
		{
			Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = rotation;
		}

		if (cooldown > 0 && player.GetComponentInChildren<PlayerController>().ability1.GetComponent<Image>().sprite.name == "Shield")
		{
			player.GetComponentInChildren<PlayerController>().ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (cooldown > 0 && player.GetComponentInChildren<PlayerController>().ability2.GetComponent<Image>().sprite.name == "Shield")
		{
			player.GetComponentInChildren<PlayerController>().ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.25f);
		}
		else if (cooldown <= 0 && player.GetComponentInChildren<PlayerController>().ability1.GetComponent<Image>().sprite.name == "Shield")
		{
			player.GetComponentInChildren<PlayerController>().ability1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
		else if (cooldown <= 0 && player.GetComponentInChildren<PlayerController>().ability2.GetComponent<Image>().sprite.name == "Shield")
		{
			player.GetComponentInChildren<PlayerController>().ability2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}

	}
}
