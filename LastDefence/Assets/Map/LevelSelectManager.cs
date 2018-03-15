using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour {
	
	public string[] levelTags;
	
	public GameObject[] locks;
	
	public bool[] levelUnlocked;
	
	public int positionSelector;
	public float distanceBelowLock;
	
	public string[] levelName;
	
	public float moveSpeed;
	
	private bool isPressed;
	
	//PlayerPrefs.SetInt(level1Tag, 1);

	// Use this for initialization
	void Start () {
		for(int i = 0; i < levelTags.Length; i++){
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
		
		
		if(!isPressed)
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
	}
}
