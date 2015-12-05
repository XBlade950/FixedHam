using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int health;
    private Vector3 toLook;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        toLook = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(toLook);

        if (health <= 0)
        {
            Debug.Log("Enemy Defeated");
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damage)
    {
        health -= damage;

    }
}
