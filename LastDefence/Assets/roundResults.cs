using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class roundResults : MonoBehaviour {


	GameObject GM;	
	private GameManager GMScript;

    public void Start()
    {
        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();  //GetComponent to access GameManager script inside object

        if (GMScript.win) {
            GameObject.Find("Win").GetComponent<Image>().enabled = true;
        } else {
            GameObject.Find("Lose").GetComponent<Image>().enabled = true;
        }

        ChangeValue(GameObject.Find("Plane").GetComponent<Text>(), GMScript.planeHit);
        ChangeValue(GameObject.Find("Bomber").GetComponent<Text>(), GMScript.bomberHit);
        ChangeValue(GameObject.Find("Tank").GetComponent<Text>(), GMScript.tankHit);
        ChangeValue(GameObject.Find("Score").GetComponent<Text>(), GMScript.score);

    }

    public void goToMap()
    {
        if (GMScript.level1Beat)
        {
            SceneManager.LoadScene("Cinematic_cleared1");
        } else
        {
            SceneManager.LoadScene("LevelMap");
        }


    }

    public void ChangeValue(Text obj, int newValue)
    {
        if (newValue < 10){
            obj.text = "0".Insert(1, newValue.ToString());
        } else {
            obj.text = newValue.ToString();
        }
    }
}


//play music 
//add game over