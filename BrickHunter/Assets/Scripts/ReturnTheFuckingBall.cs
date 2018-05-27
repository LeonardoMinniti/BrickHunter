using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTheFuckingBall : MonoBehaviour
{
    GameObject ballObject;
    public bool check;
    GameObject extraBall;
    ObjectPool objectPool;
    public GameManager extraBallsReturn;
    
    // Use this for initialization
    void Start()
    {
        check = false;
        ballObject = GameObject.FindGameObjectWithTag("Ball");
        extraBallsReturn = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }
    // Update is called once per frame
    void Update()
    {

    }

    public void nowYouGoDown()
    {
        ballObject.GetComponent<BallController>().currentBallState = BallController.ballState.endShot;


    }
    public void BallGoesDown()
    {
        ballObject.transform.position = new Vector3(0f, -4.12f, 0f);
        ballObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        MyCoroutine();

    }
    public void ExtraBallGoesOff()
    {
        StartCoroutine(MyCoroutine());
        ballObject.GetComponent<BallController>().currentBallState = BallController.ballState.endShot;

    }
    public IEnumerator MyCoroutine()
    {

        check = true;
        extraBallsReturn.GetComponent<ExtraBallManager>().numberOfBallsToFire = 0;
        yield return new WaitForSeconds(0.2f) ;

        check = false;



    }


}
