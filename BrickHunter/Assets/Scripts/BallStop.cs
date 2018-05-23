using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour {

    public Rigidbody2D ball;
    public BallController ballControl;
    private GameManager gameManager;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            //Stopping the Ball
            ball.velocity = Vector2.zero;
            //Set the ball as active
            ballControl.currentBallState = BallController.ballState.wait;
        }
        
        if(other.gameObject.tag == "Extra Ball")
        {
            gameManager.ballsInScene.Remove(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
