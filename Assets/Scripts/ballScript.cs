using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	public float zSpeed;
	public float xMax;
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		//push the ball at start
		velocity = new Vector3 (0, 0, zSpeed);
	}

	// Update is called once per frame
	void Update () {
		//move the ball continuously
		transform.position += velocity * Time.deltaTime;
	}

	//manage collisions/physics
	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Paddle") {
			float maxDist = transform.localScale.x * 0.5f + other.transform.localScale.x * 0.5f;
			float actualDist = transform.position.x - other.transform.position.x;
			float normalizedDist = actualDist / maxDist;

			velocity = new Vector3 (normalizedDist * xMax, velocity.y, -velocity.z);

		}else if (other.tag == "Wall"){
			velocity = new Vector3 (-velocity.x, velocity.y, velocity.z);
		}else if (other.tag == "Roof"){
			velocity = new Vector3 (velocity.x, velocity.y, -velocity.z);
		}else if (other.tag == "Block"){
			Destroy (other.gameObject);
			velocity = new Vector3 (velocity.x, velocity.y, -velocity.z);
			GameObject.Find("Score").GetComponent<DisplayScore>().score++;;
		}else if (other.tag == "Grey Block"){
			velocity = new Vector3 (velocity.x, velocity.y, -velocity.z);
			other.gameObject.tag = "Block";
			other.GetComponent<Renderer> ().material.color = new Color (255f, 0, 0, 255f);
		}
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
