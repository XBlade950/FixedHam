using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    private int currentHealth;
    private int currentShield;
    private string currentWeapon;

	// Use this for initialization
	void Start () 
    {
        currentHealth = 100;
        currentShield = 100;
        currentWeapon = null;
        Debug.Log(currentHealth);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Health")
        {
            currentHealth += 10;
            Debug.Log(currentHealth);
            Destroy(other.gameObject);
        }
    }
}


