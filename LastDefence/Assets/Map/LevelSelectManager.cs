﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {
	
	public string[] levelTags;
	
	public GameObject[] locks;
	
	public bool[] levelUnlocked;
	
	public int positionSelector;
	public float distanceBelowLock;
	
	public string[] levelName;
	
	public float moveSpeed;
	
	private bool isPressed;

    public Image arrow;
    public Image space;
    public bool blink = true;
	
	//PlayerPrefs.SetInt(level1Tag, 1);

	// Use this for initialization
	void Start () {
        arrow = GameObject.Find("Arrows").GetComponent<Image>();
        space = GameObject.Find("Spacebar").GetComponent<Image>();
        InvokeRepeating("Blink", 0, 1);
        for (int i = 0; i < levelTags.Length; i++){
			if(PlayerPrefs.GetInt(levelTags[i]) == null){
				levelUnlocked[i] = false;
			}
			else if(PlayerPrefs.GetInt(levelTags[i]) == 0) {
				levelUnlocked[i] = false;
			}
			else{
				levelUnlocked[i] = true;
			}
		
		
			if(levelUnlocked[i]){
				locks[i].SetActive(false);
			}
		}
		transform.position = locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0); 
		
	}
	
	//Update is called once per frame
	void Update () {
        if (!isPressed)
		{
			if(Input.GetAxis("Horizontal")> .25f){
				positionSelector += 1;
				isPressed = true;
			}
			
			else if(Input.GetAxis("Horizontal") < -.25f){
				positionSelector -= 1;
				isPressed = true;
			}
			
			if(positionSelector >= levelTags.Length){
				positionSelector = levelTags.Length - 1;
			}
			
			
			if(positionSelector < 0){
				positionSelector = 0;
			}
			
		}
		
		if(isPressed){
			if(Input.GetAxis("Horizontal") < .25f && Input.GetAxis("Horizontal")> -.25f){
				isPressed = false;
			}
			
		}
		
		transform.position = Vector3.MoveTowards(transform.position, locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);
		
		if(Input.GetKeyDown("space")) {
			if (positionSelector == 2){
				SceneManager.LoadScene("Shop");
			}
			if (positionSelector == 0) {
				SceneManager.LoadScene("Game");
			}
            if (positionSelector == 1)
            {
                SceneManager.LoadScene("Boss1");
            }
			else {
				Debug.Log("Level closed");
			}
		}
		
	}



    public void Blink() {
        if (blink){
            space.enabled = false;
            arrow.enabled = false;
            blink = false;
        } else  {
            space.enabled = true;
            arrow.enabled = true;
            blink = true;
        }

    }

}
