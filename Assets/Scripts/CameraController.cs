using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public List<Transform> players;

	public Vector3 offset;
	public Vector3 offsetFix;
	public Vector3 velocity;
	private Vector3 newPositon;
	public float smoothTime = .1f;

	public float minZoom;
	public float maxZoom;
	public float zoomLimiter;

	private Camera camera;
	private Game game;

	private void Start()
	{
		camera = gameObject.GetComponent<Camera>();
		game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
	}

	// Update is called once per frame
	void LateUpdate()
	{

		if (players.Count == 0)
		{
			return;
		}

		Move();
		Zoom();
	}

	private void Move()
	{
		Vector3 centerPoint = GetCenterPoint();

		if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lobby"))
		{
			newPositon = new Vector3(0, centerPoint.y, 0) + offset;
			transform.position = Vector3.SmoothDamp(transform.position, newPositon, ref velocity, smoothTime);
		}
		else
		{
			gameObject.transform.position = Vector3.SmoothDamp(transform.position, players[0].transform.position + offsetFix, ref velocity, smoothTime);
		}
	}

	private void Zoom()
	{
		float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/ zoomLimiter);
		camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newZoom,Time.deltaTime);
	}

	float GetGreatestDistance()
	{
		var bounds = new Bounds(players[0].position, Vector3.zero);

		for (int i = 0; i < players.Count; i++)
		{
			bounds.Encapsulate(players[i].position);
		}

		float size = 0;

		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lobby"))
		{
			size =  bounds.size.x;
		}
		else
		{
			size = bounds.size.y;
		}
		return size;
	}

	Vector3 GetCenterPoint()
	{
		if (players.Count == 1)
		{
			return players[0].position;
		}

		var bounds = new Bounds(players[0].position, Vector3.zero);
		for (int i = 0; i < players.Count; i++)
		{
			bounds.Encapsulate(players[i].position);
		}

		return bounds.center;
	}


}
