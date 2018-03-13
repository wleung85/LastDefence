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
    public int fundNow;
    public int sizeLevel;
    public int rateLevel;
    public int healthLevel;
    public int speedLevel;

    public void Start()
    {
        fund = GameObject.Find("Funds").GetComponent<Text>();
        size = GameObject.Find("SizePrice").GetComponent<Text>();
        rate = GameObject.Find("RatePrice").GetComponent<Text>();
        health = GameObject.Find("HealthPrice").GetComponent<Text>();
        speed = GameObject.Find("SpeedPrice").GetComponent<Text>();

        //get player's $$ / item cost
        fundNow = 35000;
        ChangeValue(fund, fundNow);

        sizeLevel = 0;
        rateLevel = 1;
        healthLevel = 2;
        speedLevel = 3;

        sizePrice = (sizeLevel + 1) * 5000; 
        ratePrice = (rateLevel + 1) * 5000;
        healthPrice = (healthLevel + 1) * 5000;
        speedPrice = (speedLevel + 1) * 5000;

        //display items that can be bought (blue vs grey buttons)
        if (sizeLevel >= 3) {
            Image invalid = GameObject.Find("SizeInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            Image valid = GameObject.Find("SizeValidButton").GetComponent<Image>();
            valid.enabled = true;
        }

        if (rateLevel >= 3) {
            Image invalid = GameObject.Find("RateInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            Image valid = GameObject.Find("RateValidButton").GetComponent<Image>();
            valid.enabled = true;
        }

        if (healthLevel >= 3) {
            Image invalid = GameObject.Find("HealthInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            Image valid = GameObject.Find("HealthValidButton").GetComponent<Image>();
            valid.enabled = true;
        }

        if (speedLevel >= 3) {
            Image invalid = GameObject.Find("SpeedInvalid").GetComponent<Image>();
            invalid.enabled = true;
        } else {
            Image valid = GameObject.Find("SpeedValidButton").GetComponent<Image>();
            valid.enabled = true;
        }
        //display levels of each item


        //display price of each item
        if (sizePrice > 15000){
            Debug.Log("max size reached");
            ChangeValue(size, 0);
        } else {
            ChangeValue(size, sizePrice);
        }

        if (ratePrice > 15000){
            Debug.Log("max rate reached");
            ChangeValue(rate, 0);
        } else {
            ChangeValue(rate, ratePrice);
        }

        if (healthPrice > 15000){
            Debug.Log("max health reached");
            ChangeValue(health, 0);
        } else {
            ChangeValue(health, healthPrice);
        }

        if (speedPrice > 15000){
            Debug.Log("max speed reached");
            ChangeValue(speed, 0);
        } else {
            ChangeValue(speed, sizePrice);
        }
    }

    public void Back(){
        SceneManager.LoadScene("Map");
    }

    public void ChangeValue(Text obj, int newValue){
        if (newValue == 0){
            obj.text = "";
        } else {
            obj.text = "$".Insert(1, newValue.ToString());
        }
    }

    public void BuySize(){
        Debug.Log("buying size...");
        if (fundNow < sizePrice){
            NoFunds();
        } else {
            Debug.Log("Enough funds");
            if (sizePrice >= 15000) {
                Debug.Log("max size reached");
                Image invalid = GameObject.Find("SizeInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("SizeValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                sizeLevel++;
                fundNow = fundNow - sizePrice;
                sizePrice = sizePrice + 5000;
                ChangeValue(size, 0);
                ChangeValue(fund, fundNow);
            } else {
                sizeLevel++;
                fundNow = fundNow - sizePrice;
                sizePrice = sizePrice + 5000;
                ChangeValue(size, sizePrice);
                ChangeValue(fund, fundNow);
            }
            updateSizeLevel();
        }
    }

    public void BuyRate(){
        Debug.Log("buying rate...");
        if (fundNow < ratePrice){
            NoFunds();
        } else {
            Debug.Log("Enough funds");
            if (ratePrice >= 15000) {
                Debug.Log("max rate reached");
                Image invalid = GameObject.Find("RateInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("RateValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                rateLevel++;
                fundNow = fundNow - ratePrice;
                ratePrice = ratePrice + 5000;
                ChangeValue(rate, 0);
                ChangeValue(fund, fundNow);
            } else {
                rateLevel++;
                fundNow = fundNow - ratePrice;
                ratePrice = ratePrice + 5000;
                ChangeValue(rate, ratePrice);
                ChangeValue(fund, fundNow);
            }
            updateRateLevel();
        }
    }

    public void BuyHealth()
    {
        Debug.Log("buying health...");
        if (fundNow < healthPrice) {
            NoFunds();
        } else {
            Debug.Log("Enough funds");
            if (healthPrice >= 15000) {
                Debug.Log("max health reached");
                Image invalid = GameObject.Find("HealthInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("HealthValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                healthLevel++;
                fundNow = fundNow - healthPrice;
                healthPrice = healthPrice + 5000;
                ChangeValue(health, 0);
                ChangeValue(fund, fundNow);
            } else {
                healthLevel++;
                fundNow = fundNow - healthPrice;
                healthPrice = healthPrice + 5000;
                ChangeValue(health, healthPrice);
                ChangeValue(fund, fundNow);
            }
            updateHealthLevel();
        }
    }

    public void BuySpeed() {
        Debug.Log("buying speed...");
        if (fundNow < speedPrice) {
            NoFunds();
        } else {
            Debug.Log("Enough funds");
            if (speedPrice >= 15000) {
                Debug.Log("max size reached");
                Image invalid = GameObject.Find("SpeedInvalid").GetComponent<Image>();
                Image valid = GameObject.Find("SpeedValidButton").GetComponent<Image>();
                invalid.enabled = true;
                valid.enabled = false;
                speedLevel++;
                fundNow = fundNow - speedPrice;
                speedPrice = speedPrice + 5000;
                ChangeValue(speed, 0);
                ChangeValue(fund, fundNow);
            } else {
                speedLevel++;
                fundNow = fundNow - speedPrice;
                speedPrice = speedPrice + 5000;
                ChangeValue(speed, speedPrice);
                ChangeValue(fund, fundNow);
            }
            updateSpeedLevel();
        }
    }

    public void updateSizeLevel()
    {

    }

    public void updateRateLevel()
    {

    }

    public void updateHealthLevel()
    {

    }

    public void updateSpeedLevel()
    {

    }

    public void NoFunds() {
        Debug.Log("Not enough funds");
    }
}