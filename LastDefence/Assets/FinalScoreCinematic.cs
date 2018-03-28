using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreCinematic : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    private GameObject GameManager;
    private GameManager GMScript;

    void Start () {
        GameManager = GameObject.Find("GameManager");
        GMScript = GameManager.GetComponent<GameManager>();
        scoreText.text = "FINAL SCORE: " + GMScript.score;
	}
	
}
