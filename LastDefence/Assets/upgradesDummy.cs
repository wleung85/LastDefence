using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class upgradesDummy : MonoBehaviour {


	GameObject GM;	
	private GameManager GMScript;
    public int health = 3;
    public bool halfLife = false;
    public bool lose = false;
    public bool stop = false;
    public bool complete = false;
    public Image L1;
    public Image L2;
    public Image L3;
    public Image L4;
    public Image L5;
    public Image L6;

    public Image H1;
    public Image H2;
    public Image H3;
    public Image H4;
    public Image H5;
    public Image H6;

    public Text score;

    public void Start()
    {
        GM = GameObject.Find("GameManager");        //GameObject.Find to get GameManager
        GMScript = GM.GetComponent<GameManager>();  //GetComponent to access GameManager script inside object

        L1 = GameObject.Find("life1").GetComponent<Image>();
        L2 = GameObject.Find("life2").GetComponent<Image>();
        L3 = GameObject.Find("life3").GetComponent<Image>();

        H1 = GameObject.Find("half1").GetComponent<Image>();
        H2 = GameObject.Find("half2").GetComponent<Image>();
        H3 = GameObject.Find("half3").GetComponent<Image>();

        score = GameObject.Find("Score").GetComponent<Text>();

        ChangeValue(score, GMScript.score);

        if (GMScript.healthLevel >= 1) {
            health = 4;
            L4 = GameObject.Find("life4").GetComponent<Image>();
            H4 = GameObject.Find("half4").GetComponent<Image>();
            L4.enabled = true;
            H4.enabled = true;
        }
        if (GMScript.healthLevel >= 2){
            health = 5;
            L5 = GameObject.Find("life5").GetComponent<Image>();
            H5 = GameObject.Find("half5").GetComponent<Image>();
            L5.enabled = true;
            H5.enabled = true;
        }
        if (GMScript.healthLevel >= 3) {
            health = 6;
            L6 = GameObject.Find("life6").GetComponent<Image>();
            H6 = GameObject.Find("half6").GetComponent<Image>();
            L6.enabled = true;
            H5.enabled = true;
        }
    }

    public void hitHealth() {
        Image img;

        if (!stop)  {
            if (!halfLife)  {
                if (health == 1) {
                    img = L1;
                } else {
                    if (health == 2) {
                        img = L2;
                    } else {
                        if (health == 3) {
                            img = L3;
                        } else  {
                            if (health == 4) {
                                img = L4;
                            }else  {
                                if (health == 5)  {
                                    img = L5;
                                }  else  {
                                    img = L6;
                                }
                            }
                        }
                    }
                }
                halfLife = true;
            } else {
                if (health == 1) {
                    img = H1;
                }  else {
                    if (health == 2)  {
                        img = H2;
                    } else  {
                        if (health == 3) {
                            img = H3;
                        }  else {
                            if (health == 4)
                            {
                                img = H4;
                            }  else{
                                if (health == 5) {
                                    img = H5;
                                } else {
                                    img = H6;
                                }
                            }
                        }
                    }
                }
                halfLife = false;
                health--;
            }
            StartCoroutine(BlinkHealth(img));
            if (health == 0)  {
                stop = true;
                gameOver();
            }
        }
        
    }

    public void Update()
    {
        if (lose){
            GMScript.win = false;
            if (!GMScript.bossLevel) {
                SceneManager.LoadScene("RoundResults");
            } else {
                SceneManager.LoadScene("LevelMap");
            }
        }

        if (complete) {
            Debug.Log("Level Complete");
            GMScript.win = true;
            if (!GMScript.bossLevel) {
                SceneManager.LoadScene("RoundResults");

            } else  {
                SceneManager.LoadScene("Cinematic_endboss1");
            }
        }
    }

    public void WinLevel(){
        stop = true;
        StartCoroutine(BlinkWin(GameObject.Find("LevelComplete").GetComponent<Image>()));
    }
    public void gameOver(){
        StartCoroutine(BlinkLose(GameObject.Find("GameOver").GetComponent<Image>()));
    }

    IEnumerator BlinkHealth(Image img){
        AudioSource a = GameObject.Find("Damage").GetComponent<AudioSource>();
        a.Play();
        img.enabled = false;
        yield return new WaitForSeconds(0.04F);
        img.enabled = true;
        yield return new WaitForSeconds(0.04F);
        img.enabled = false;
        yield return new WaitForSeconds(0.04F);
        img.enabled = true;
        yield return new WaitForSeconds(0.04F);
        img.enabled = false;
    }

    IEnumerator BlinkLose(Image img){
        AudioSource a = GameObject.Find("Lose").GetComponent<AudioSource>();
        a.Play();
        for (int i = 0; i < 3; i++)
        {
            img.enabled = true;
            yield return new WaitForSeconds(1);
            img.enabled = false;
            yield return new WaitForSeconds(1);
        }
        lose = true;
    }

    IEnumerator BlinkWin(Image img)
    {
        AudioSource a = GameObject.Find("Win").GetComponent<AudioSource>();
        a.Play();
        for (int i = 0; i < 3; i++)
        {
            img.enabled = true;
            yield return new WaitForSeconds(1);
            img.enabled = false;
            yield return new WaitForSeconds(1);
        }
        complete = true;
    }


    public void ChangeValue(Text obj, int newValue){
         obj.text = "Score: ".Insert(7, newValue.ToString());
    }

    public void DummyIncreaseScore() {
        if (!stop) {
            GMScript.score = GMScript.score + 200;
            ChangeValue(score, GMScript.score);
        }
    }
}