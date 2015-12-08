using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int health;
    public GameObject player;
    public float speed;
    public float offset;
    public float startPos;
    private bool start;

	// Use this for initialization
	void Start () {
        health = 100;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Transform>();
        gameObject.GetComponent<Transform>();
        start = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            Debug.Log("Enemy Defeated");
            Destroy(gameObject);
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y+.5f, gameObject.transform.position.z);
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < startPos)
        {
            start = true;
        }


        if (start)
        {
            Vector3 desired_velocity = Vector3.Normalize(player.transform.position - gameObject.transform.position) * (speed * Time.deltaTime);




            if (Vector3.Distance(player.transform.position, gameObject.transform.position) > offset)
            {
                gameObject.transform.position += desired_velocity;
            }

            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= offset)
            {
                gameObject.transform.position -= desired_velocity;
            }

            transform.LookAt(player.transform);
        }

	}

    public void takeDamage(int damage)
    {
        health -= damage;

    }
}
