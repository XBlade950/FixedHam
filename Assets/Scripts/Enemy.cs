using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Debug.Log("Enemy Defeated");
            Destroy(gameObject);
        }
	}

    public void takeDamage()
    {
        health -= 20;

    }
}
