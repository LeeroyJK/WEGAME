﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
//Line55 Player Die Text field
public class Player_health : MonoBehaviour {

    private PlayerMaster playerMaster;
    private GameManager_Master gameManagerMaster;
    public int playerHealth = 100;
    public UnityEngine.UI.Text healthText;
    public static UnityEngine.UI.Text scores;

    public int score = 0;


    private void OnEnable()
    {
        setInit();
        SetUI();
        playerMaster.EventPlayerHealthDecrease += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }
    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDecrease += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void Start()
    {
       // StartCoroutine(TestHealthDecrease());
    }
    void setInit()
    {
      //  gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<PlayerMaster>();
    }

    IEnumerator TestHealthDecrease()
    {
        yield return new WaitForSeconds(2);
        playerMaster.CallEventPlayerDecrease(50);
    }

    void DeductHealth(int change)
    {
        playerHealth -= change;
        if(playerHealth <= 0)
        {
            playerHealth = 0;

            //Not finish yet.
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");

            
        }

        SetUI();
    }

    void IncreaseHealth(int change)
    {
        playerHealth += change;
        if(playerHealth > 100)
        {
            playerHealth = 100;
        }
        SetUI();
    }
    public void SetUI()
    {
        if(healthText != null)
        {
            healthText.text= playerHealth.ToString();
        }
        if(scores != null)
        {
            scores.text= score.ToString();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HPITEM"))
        {
            print("enter HP Item");
            playerHealth += 10;
            Destroy(other.gameObject);
            SetUI();
        }
    }
}
