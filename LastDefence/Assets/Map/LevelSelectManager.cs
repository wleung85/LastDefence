using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour {
	
	public string[] levelTags;
	
	public GameObject[] locks;
	
	public bool[] levelUnlocked;
	
	PlayerPrefs.SetInt(level1Tag, 1);

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
