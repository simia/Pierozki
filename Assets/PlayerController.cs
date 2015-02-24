using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private CharacterController controller;

	public float speed;// = 13f;
	public float gravity;// = 20f;
	public float jumpSpeed;// = 0.1f;
	Vector3 moveDirection = Vector3.zero;

	public int timeToCheckpoint = 100;

	private float checkpointTimer = 0f;

	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		controller.detectCollisions = true;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection.z = speed;
		if (controller.isGrounded ) 
		{				
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		checkpointTimer += Time.deltaTime;
		if (checkpointTimer >= 1f) 
		{
			timeToCheckpoint--;
			checkpointTimer -= 1f;
		}
		//timeToCheckpoint = (int)((float)timeToCheckpoint - Time.deltaTime);
	}


	public void ChangeSpeed(float newspeed)
	{
		speed = newspeed;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//print (hit.gameObject.name);
		if (hit.gameObject.tag == "Obstacle") 
		{
			IObstacle obstacle = hit.gameObject.GetComponent(typeof(IObstacle)) as IObstacle;
			obstacle.DoJob(this);
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Checkpoint") 
		{
			speed = 0;
		}
	}


	public int TimeToCheckpoint {
		get {
			return timeToCheckpoint;
		}
	}

	public float Speed {
		get {
			return speed;
		}
	}
}
