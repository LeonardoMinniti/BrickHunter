using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickHealthManager : MonoBehaviour {
    public int brickHealth;
    private Text brickHealthText;
    private GameManager gameManager;
    private ScoreManager score;
	// Use this for initialization
	void Start () {
        score = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager> ();
        brickHealth = gameManager.level;
        brickHealthText = GetComponentInChildren<Text>();
		
	}

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        brickHealth = gameManager.level;
    }

    // Update is called once per frame
    void Update () {
        brickHealthText.text = "" + brickHealth;
        if(brickHealth<= 0)
        {
            this.gameObject.SetActive(false);
        }
		
	}

    void TakeDamage(int damageToTake)
    {
        brickHealth -= damageToTake;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            TakeDamage(1);
            score.IncreaseScore();
        }
        
    }
}
