using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    

    private Vector3 mousePosition;
    private Vector3 worldPosition;
    private Vector3 moveDirection = Vector3.zero;
    private float cameraDif;
    public float gravity = 20f;
    public GameObject bullet;
    private CharacterController controller;
    public float jumpSpeed = 8f;


    public int speed;
	// Use this for initialization
	void Start () {
        cameraDif = Camera.main.transform.position.y - transform.position.y;
        bullet = (GameObject)Resources.Load("PlayerStandardBullet");
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        worldPosition = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(cameraDif);
        worldPosition.y = transform.position.y;
        transform.LookAt(worldPosition);


        //controller.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Clicked");
            Vector3 toInstantiate = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(bullet, toInstantiate + (transform.forward*1f), transform.rotation);
            

        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse Clicked");
            bullet = (GameObject)Resources.Load("PlayerOneShotBullet");
            Vector3 toInstantiate = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(bullet, toInstantiate + (transform.forward * 1f), transform.rotation);
            bullet = (GameObject)Resources.Load("PlayerStandardBullet");


        }

        
        

        //Moves player with Character Controller
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);
            moveDirection *= speed; 
        }

        if (Input.GetKeyDown("space") && controller.isGrounded)
        {
            Debug.Log("Space Pressed");
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
        
	}

    /*void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
        
    }*/
}
