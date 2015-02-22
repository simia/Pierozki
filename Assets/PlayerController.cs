using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private CharacterController controller;

	public float speed;// = 13f;
	public float gravity;// = 20f;
	public float jumpSpeed;// = 0.1f;
	Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
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
		print (moveDirection);

		//if (!controller.isGrounded) 
		//{
			moveDirection.y -= gravity * Time.deltaTime;
		//}
		controller.Move(moveDirection * Time.deltaTime);

	}
}
