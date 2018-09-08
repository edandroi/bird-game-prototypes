using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	public KeyCode up;
	private Rigidbody2D rb;
	float force = 100f;
	private float currentForce;

	private SpriteRenderer playerSprite;
	private Sprite[] sprites;
	public Sprite birdUp;
	public Sprite birdDown;

	
	// Use this for initialization
	void Start ()
	{
//		sprites = Resources.LoadAll<Sprite>("bird-blue-1", "bird-blue-2");
		rb = GetComponent<Rigidbody2D>();
		playerSprite = GetComponent<SpriteRenderer>();
//		birdDown = Resources.Load<Sprite>("bird-blue-2");
		currentForce = force;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKey(up))
		{
			currentForce += 10;
			playerSprite.sprite = birdDown;
		}

		if (Input.GetKeyUp(up))
		{
			playerSprite.sprite = birdUp;
			rb.AddForce(transform.up*currentForce);
			currentForce = force;
		}

	}
}
