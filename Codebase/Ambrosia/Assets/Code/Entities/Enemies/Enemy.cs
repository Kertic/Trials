using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all enemies
/// </summary>
public class Enemy : MonoBehaviour {

    int health;
    int maxHealth;
    //Encapsulated using Id
    private int id;
    public int Id
    {
        get
        {
            return id;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(int damage)
    {
        health -= damage;
        if (health > 0)
            health = 0;
        
    }
}
