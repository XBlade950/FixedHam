using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDamage()
    {
        health -= 5;
    }

    public void addHealth()
    {

    }
}
