using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMovementController : MonoBehaviour {
    public enum brickState
    {
        stop,
        move
    }

    public brickState currentState;
    private bool hasMoved;

	// Use this for initialization
	void Start () {
        hasMoved = false;
        currentState = brickState.stop;
		
	}

    private void OnEnable()
    {
        hasMoved = false;
        currentState = brickState.stop;
    }

    // Update is called once per frame
    void Update () {
        if(currentState == brickState.stop)
        {
            hasMoved = false;
        }
        if(currentState == brickState.move)
        {
            if (hasMoved == false)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                currentState = brickState.stop;
               
                hasMoved = true;
            }
        }
		
	}
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ich war hier 111");
        if (other.tag == "Square Brick" || other.tag == "Triangle Brick" || other.tag == "Extra Ball PowerUp")
        {
            Debug.Log("ich war hier");
            other.gameObject.SetActive(false);
        }

    }*/
}
