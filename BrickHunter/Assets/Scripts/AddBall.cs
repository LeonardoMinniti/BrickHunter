﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour {

    private ExtraBallManager extraBallManager;

	// Use this for initialization
	void Start () {
        extraBallManager = FindObjectOfType<ExtraBallManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            //add an extra ball to the count
            extraBallManager.numberOfExtraBalls++;
            this.gameObject.SetActive(false);
        }
    }
}
