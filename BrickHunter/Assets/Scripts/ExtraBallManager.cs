using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraBallManager : MonoBehaviour {

    private BallController ballController;
    private GameManager gameManager;
    public float ballWaitTime;
    private float ballWaitTimeSeconds;
    public int numberOfExtraBalls;
    public int numberOfBallsToFire;
    public ObjectPool objectPool;
    public Text numberOfBallsText;
    public ReturnTheFuckingBall extraBall;
    public GameManager extraBallsReturn;


    // Use this for initialization
    void Start () {
        ballController = FindObjectOfType<BallController>();
        gameManager = FindObjectOfType<GameManager>();
        extraBall = FindObjectOfType<ReturnTheFuckingBall>();
        ballWaitTimeSeconds = ballWaitTime;
        numberOfExtraBalls = 0;
        numberOfBallsToFire = 0;
        numberOfBallsText.text = "" + 1;
        extraBallsReturn = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        numberOfBallsText.text = "" + (numberOfExtraBalls + 1);

        
        if(ballController.currentBallState == BallController.ballState.fire || ballController.currentBallState == BallController.ballState.wait)
        {
            if(numberOfBallsToFire > 0)
            {
                ballWaitTimeSeconds -= Time.deltaTime;
                if(ballWaitTimeSeconds <= 0)
                {
                    GameObject ball = objectPool.GetPooledObject("Extra Ball");
                    if(ball != null)
                    {
                        ball.transform.position = ballController.ballLaunchPosition;
                        ball.SetActive(true);
                        gameManager.ballsInScene.Add(ball);
                        ball.GetComponent<Rigidbody2D>().velocity = ballController.tempVelocity * ballController.constantSpeed;
                        ballWaitTimeSeconds = ballWaitTime;
                        numberOfBallsToFire--;
                    }
                    ballWaitTimeSeconds = ballWaitTime;
                }
            }
        }

        if(extraBall.check == true)
        {
            for (int i = 1; i < extraBallsReturn.ballsInScene.Count; i++)
            {
                extraBallsReturn.ballsInScene[i].transform.position = new Vector3(0f, -4.12f, 0f);
                extraBallsReturn.ballsInScene[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1f);
                //extraBallsReturn.ballsInScene[i].SetActive(false);

            }
            for (int i = 1; i < extraBallsReturn.ballsInScene.Count; i++)
            {
                extraBallsReturn.ballsInScene.Remove(extraBallsReturn.ballsInScene[i]);
            }
        }

        if (ballController.currentBallState == BallController.ballState.endShot)
        {
            numberOfBallsToFire = numberOfExtraBalls;
        }
    }
}
