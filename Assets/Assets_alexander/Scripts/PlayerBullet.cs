using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public float speed = 1;
    private GameObject player;
    public float bulletDistance = 50f;
    public int damage = 20;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward*speed;

        //deletes if bullet is very far away(off screen)
        Vector3 diff = transform.position - player.transform.position;
        if(diff.magnitude > bulletDistance)
            Destroy(gameObject);
	}

    void OnCollisionEnter(Collision col)
    {
        GameObject obj = col.gameObject;
        
        Debug.Log("Bullet hit something");
        if (obj.tag == "enemy"){
            obj.GetComponent<Enemy>().takeDamage(damage);
        }
        if (obj.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    
}
