using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public Text fund;
    public Text size;
    public Text rate;
    public Text health;
    public Text speed;
    public int sizePrice;
    public int ratePrice;
    public int healthPrice;
    public int speedPrice;
    public Image sizeL1;
    public Image sizeL2;
    public Image sizeL3;
    public Image rateL1;
    public Image rateL2;
    public Image rateL3;
    public Image healthL1;
    public Image healthL2;
    public Image healthL3;
    public Image speedL1;
    public Image speedL2;
    public Image speedL3;
	GameObject GM;	
	private GameManager GMScript;
	
    

    public void Start()
    {
		GM = GameObject.Find("GameManager");		//GameObject.Find to get GameManager
		GMScript = GM.GetComponent<GameManager>();	//GetComponent to access GameManager script inside object
        fund = GameObject.Find("Funds").GetComponent<Text>();
        size = GameObject.Find("SizePrice").GetComponent<Text>();
        rate = GameObject.Find("RatePrice").GetComponent<Text>();
        health = GameObject.Find("HealthPrice").GetComponent<Text>();
        speed = GameObject.Find("SpeedPrice").GetComponent<Text>();

        //get player's $$ / item cost
        ChangeValue(fund, GMScript.score);

        sizePrice = (GMScript.sizeLevel + 1) * 5000; 
        ratePrice = (GMScript.rateLevel + 1) * 5000;
        healthPrice = (GMScript.healthLevel + 1) * 5000;
        speedPrice = (GMScript.speedLevel + 1) * 5000;


        //display levels/cost of each item
        sizeL1 = GameObject.Find("SizeL1").GetComponent<Image>();
        sizeL2 = GameObject.Find("SizeL2").GetComponent<Image>();
        sizeL3 = GameObject.Find("SizeL3").GetComponent<Image>();
        rateL1 = GameObject.Find("RateL1").GetComponent<Image>();
        rateL2 = GameObject.Find("RateL2").GetComponent<Image>();
        rateL3 = GameObject.Find("RateL3").GetComponent<Image>();
        healthL1 = GameObject.Find("HealthL1").GetComponent<Image>();
        healthL2 = GameObject.Find("HealthL2").GetComponent<Image>();
        healthL3 = GameObject.Find("HealthL3").GetComponent<Image>();
        speedL1 = GameObject.Find("SpeedL1").GetComponent<Image>();
        speedL2 = GameObject.Find("SpeedL2").GetComponent<Image>();
        speedL3 = GameObject.Find("SpeedL3").GetComponent<Image>();

        if (GMScript.sizeLevel == 3) {
            sizeL3.enabled = true;
            ChangeValue(size, 0);
            Image invalid = GameObject.Find("SizeInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            ChangeValue(size, sizePrice);
            Image valid = GameObject.Find("SizeValidButton").GetComponent<Image>();
            valid.enabled = true;
            if (GMScript.sizeLevel == 2) {
                sizeL2.enabled = true;
            } else {
                if (GMScript.sizeLevel == 1) {
                    sizeL1.enabled = true;
                }
            }
        }

        if (GMScript.rateLevel == 3){
            rateL3.enabled = true;
            ChangeValue(rate, 0);
            Image invalid = GameObject.Find("RateInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            ChangeValue(rate, ratePrice);
            Image valid = GameObject.Find("RateValidButton").GetComponent<Image>();
            valid.enabled = true;
            if (GMScript.rateLevel == 2) {
                rateL2.enabled = true;
            } else {
                if (GMScript.rateLevel == 1) {
                    rateL1.enabled = true;
                }
            }
        }

        if (GMScript.healthLevel == 3) {
            healthL3.enabled = true;
            ChangeValue(health, 0);
            Image invalid = GameObject.Find("HealthInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            ChangeValue(health, healthPrice);
            Image valid = GameObject.Find("HealthValidButton").GetComponent<Image>();
            valid.enabled = true;
            if (GMScript.healthLevel == 2) {
                healthL2.enabled = true;
            } else {
                if (GMScript.healthLevel == 1) {
                    healthL1.enabled = true;
                }
            }
        }

        if (GMScript.speedLevel == 3) {
            speedL3.enabled = true;
            ChangeValue(speed, 0);
            Image invalid = GameObject.Find("SpeedInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            ChangeValue(speed, speedPrice);
            Image valid = GameObject.Find("SpeedValidButton").GetComponent<Image>();
            valid.enabled = true;
            if (GMScript.speedLevel == 2) {
                speedL2.enabled = true;
            } else {
                if (GMScript.speedLevel == 1) {
                    speedL1.enabled = true;
                }
            }
        }
    }

    public void Back(){
        SceneManager.LoadScene("LevelMap");
    }

    public void ChangeValue(Text obj, int newValue){
            obj.text = "$".Insert(1, newValue.ToString());

    }

    public void BuySize(){
        if (GMScript.score < sizePrice){
            NoFunds();
        } else {
            Debug.Log("buying size...Enough funds");
            if (sizePrice >= 15000) {
                Debug.Log("max size reached");
                Image invalid = GameObject.Find("SizeInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("SizeValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                GMScript.sizeLevel++;
                GMScript.score = GMScript.score - sizePrice;
                sizePrice = sizePrice + 5000;
                ChangeValue(size, 0);
                ChangeValue(fund, GMScript.score);
            } else {
                GMScript.sizeLevel++;
                GMScript.score = GMScript.score - sizePrice;
                sizePrice = sizePrice + 5000;
                ChangeValue(size, sizePrice);
                ChangeValue(fund, GMScript.score);
            }
            updateSizeLevel();
        }
    }

    public void BuyRate(){
        if (GMScript.score < ratePrice){
            NoFunds();
        } else {
            Debug.Log("buying rate...Enough funds");
            if (ratePrice >= 15000) {
                Debug.Log("max rate reached");
                Image invalid = GameObject.Find("RateInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("RateValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                GMScript.rateLevel++;
                GMScript.score = GMScript.score - ratePrice;
                ratePrice = ratePrice + 5000;
                ChangeValue(rate, 0);
                ChangeValue(fund, GMScript.score);
            } else {
                GMScript.rateLevel++;
                GMScript.score = GMScript.score - ratePrice;
                ratePrice = ratePrice + 5000;
                ChangeValue(rate, ratePrice);
                ChangeValue(fund, GMScript.score);
            }
            updateRateLevel();
        }
    }

    public void BuyHealth()
    {
        if (GMScript.score < healthPrice) {
            NoFunds();
        } else {
            Debug.Log("buying health...");
            if (healthPrice >= 15000) {
                Debug.Log("max health reached");
                Image invalid = GameObject.Find("HealthInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("HealthValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                GMScript.healthLevel++;
                GMScript.score = GMScript.score - healthPrice;
                healthPrice = healthPrice + 5000;
                ChangeValue(health, 0);
                ChangeValue(fund, GMScript.score);
            } else {
                GMScript.healthLevel++;
                GMScript.score = GMScript.score - healthPrice;
                healthPrice = healthPrice + 5000;
                ChangeValue(health, healthPrice);
                ChangeValue(fund, GMScript.score);
            }
            updateHealthLevel();
        }
    }

    public void BuySpeed() {
        if (GMScript.score < speedPrice) {
            NoFunds();
        } else {
            Debug.Log("buying speed...Enough funds");
            if (speedPrice >= 15000) {
                Debug.Log("max size reached");
                Image invalid = GameObject.Find("SpeedInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("SpeedValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                GMScript.speedLevel++;
                GMScript.score = GMScript.score - speedPrice;
                speedPrice = speedPrice + 5000;
                ChangeValue(speed, 0);
                ChangeValue(fund, GMScript.score);
            } else {
                GMScript.speedLevel++;
                GMScript.score = GMScript.score - speedPrice;
                speedPrice = speedPrice + 5000;
                ChangeValue(speed, speedPrice);
                ChangeValue(fund, GMScript.score);
            }
            updateSpeedLevel();
        }
    }

    public void updateSizeLevel()
    {
        if (GMScript.sizeLevel == 1) {
            sizeL1.enabled = true;
        } else {
            if (GMScript.sizeLevel == 2) {
                sizeL2.enabled = true;
            } else {
                sizeL3.enabled = true;
            }
        }
    }

    public void updateRateLevel()
    {
        if (GMScript.rateLevel == 1) {
            rateL1.enabled = true;
        } else {
            if (GMScript.rateLevel == 2) {
                rateL2.enabled = true;
            } else {
                rateL3.enabled = true;
            }
        }
    }

    public void updateHealthLevel()
    {
        if (GMScript.healthLevel == 1) {
            healthL1.enabled = true;
        } else {
            if (GMScript.healthLevel == 2) {
                healthL2.enabled = true;
            } else {
                healthL3.enabled = true;
            }
        }
    }

    public void updateSpeedLevel()
    {
        if (GMScript.speedLevel == 1) {
            speedL1.enabled = true;
        } else {
            if (GMScript.speedLevel == 2) {
                speedL2.enabled = true;
            } else {
                speedL3.enabled = true;
            }
        }
    }

    public void NoFunds() {
        Debug.Log("Not enough funds");
        Image error = GameObject.Find("Error").GetComponent<Image>();
        StartCoroutine(ShowError(error, 1));
    }

    IEnumerator ShowError(Image img, float delay)
    {
        img.enabled = true;
        yield return new WaitForSeconds(delay);
        img.enabled = false;
    }



    public void goToGame()
    {
        SceneManager.LoadScene("Game HEALTH SCORE");
    }
}