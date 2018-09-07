using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	public KeyCode up;
	private Rigidbody2D rb;
	float force = 100f;
	private float currentForce;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		currentForce = force;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKey(up))
		{
			currentForce += 10;
		}

		if (Input.GetKeyUp(up))
		{
			rb.AddForce(transform.up*currentForce);
			currentForce = force;
		}

	}
}
