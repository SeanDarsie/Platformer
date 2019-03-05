using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	[SerializeField] float rotSpeed;
	[SerializeField] float leftEdge;
	[SerializeField] float rightEdge;
	[SerializeField] Vector2 jumpForce;
	[SerializeField] float hSpeed;
	public bool grounded;
	Rigidbody2D rb;
	[SerializeField] int rotationFrames = 30;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (grounded == true)
			{
				Jump();
			}
			// jump if grounded
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x < rightEdge)
				transform.Translate(new Vector3(hSpeed,0,0),Space.World);			
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.position.x > leftEdge)
				transform.Translate(new Vector3(-hSpeed,0,0), Space.World);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (grounded == false)
				rb.gravityScale = 10.0f;
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			rb.gravityScale = 3.0f;
		}

		if (transform.position.x >= rightEdge)
			transform.position = new Vector3(rightEdge, transform.position.y,transform.position.z);
		if (transform.position.x <= leftEdge)
			transform.position = new Vector3(leftEdge, transform.position.y,transform.position.z);
	}
	void Jump() 
	{
		rb.AddForce(jumpForce);
		grounded = false;
	}
	
	void OnCollisionEnter2D(Collision2D other) // player has collided with a platform.
	{
		if (other.gameObject.transform.position.y < transform.position.y)
		{
			grounded = true;
			rb.gravityScale = 3.0f;
		}
	}
	
	void OnCollisionExit2D(Collision2D other) // don't allow jumps if the player has left the platform.
	{
		grounded = false;
	}
}
