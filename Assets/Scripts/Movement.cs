using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public Vector3 speed;
	public Transform floor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		input();
		calcPos();
	}

	//manage Inputs
	void input()
	{
		//reset game on button press "R"
		if (Input.GetKeyDown("r"))
		{
			GameObject.Find("Ball").transform.position = new Vector3(0, 0.5f, -4f);
			SceneManager.LoadScene(0);
			Time.timeScale = 1;
		}
	}

	//calculate new positio9n
	void calcPos()
	{
		float dir = Input.GetAxis("Horizontal");
		float newPos = this.transform.position.x + dir * Time.deltaTime * speed.x;

		float paddleScale = transform.localScale.x;
		float floorScale = floor.localScale.x;
		float maxPos = floorScale * 10 * 0.5f - paddleScale * 1 * 0.5f - 1f;

		float pos = Mathf.Clamp(newPos, -maxPos, +maxPos);
		transform.position = new Vector3(pos, transform.position.y, transform.position.z);
	}
}