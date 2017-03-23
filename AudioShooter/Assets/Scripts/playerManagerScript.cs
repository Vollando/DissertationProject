﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerManagerScript : NetworkBehaviour {

    [SerializeField]
    private int maxHealth = 10;

    [SyncVar]
    private int currentHealth;

    void Awake ()
    {
        SetDefaults();
    }

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health");
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
