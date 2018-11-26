﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {
    private Enemy_Master enemyMaster;
    public int enemyHealth = 100;
    public int score;
    public UnityEngine.UI.Text scores;    

    private void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDeductHealth += DeductHealth;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDeductHealth -= DeductHealth;
    }

    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
    }

    void DeductHealth(int change)
    {
        enemyHealth -= change;
        if(enemyHealth <= 0)
        {
            enemyHealth = 0;
            enemyMaster.CallEventEnemyDie();
            Destroy(gameObject, Random.Range(5, 10));
            score += 10;
            SetUI();

        }
    }
    void isDead()
    {
        if(enemyHealth <= 0)
        {
            
        }
    }
    void SetUI()
    {
        if(scores != null)
        {
            scores.text= score.ToString();
        }
    }

}