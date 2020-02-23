using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	Text txt;
	Text wonlost;
    Text lifeText;
	public int score = 0;
    public int life = 3;
    Transform ball;


	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text>();
		wonlost = GameObject.Find("WonLost").GetComponent<Text>();
        lifeText = GameObject.Find("Life").GetComponent<Text>();
        ball = GameObject.Find("Ball").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //update score and life text
		txt.text="Score : " + score;
        lifeText.text = "Life : " + life;

        checkWinCondition();
        checkLosingCondition();
    }

    //check if game is won
    void checkWinCondition()
    {
        if (score >= 54)
        {
            wonlost.text = "You won \n press R to play again";
            Time.timeScale = 0;
        }
    }

    //check if game is lost
    void checkLosingCondition()
    {
        if (ball.position.z < -10.5f)
        {
            if (life <= 1)
            {
                wonlost.text = "You lost \n press R to play again";
                Time.timeScale = 0;
            }
            else
            {
                life--;
                GameObject.Find("Ball").transform.position = new Vector3(0, 0.5f, -4f);
                GameObject.Find("Ball").GetComponent<ballScript>().velocity = new Vector3(0, 0, GameObject.Find("Ball").GetComponent<ballScript>().zSpeed);
            }
        }
    }
}
