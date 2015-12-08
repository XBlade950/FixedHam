using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
	    offset = transform.position - player.transform.position;
        //player = GameObject.FindGameObjectWithTag("Player");
        //offset.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
        
	}
}
