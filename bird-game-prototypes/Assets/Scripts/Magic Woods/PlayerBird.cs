using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
	// Keys for movement
	public KeyCode right;
	public KeyCode left;
	
	// Sprites
	public Sprite birdUp;
	public Sprite birdDown;
	
	//Keys for changing colors
	public KeyCode c_Btn1;
	public KeyCode c_Btn2;
	public KeyCode c_Btn3;
	
	public Color32 pickedColor;

	public float speed;
	public float angle;
	
	private SpriteRenderer m_SpriteRenderer;
	private Color m_NewColor;
	
	// Color Manager
	public ColorManager m_ColorManager;
	private Color32 C_pink;
	private Color32 C_blue;
	private Color32 C_yellow;

	private Vector3 initialPos;
	
	// Use this for initialization
	void Start () 
	{
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		pickedColor = m_SpriteRenderer.color;
	
		// Get the colors from Color Manager
		m_ColorManager = GameObject.Find("Color Manager").GetComponent<ColorManager>();
		C_pink = m_ColorManager.C_pink;
		C_blue = m_ColorManager.C_blue;
		C_yellow = m_ColorManager.C_yellow;

		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_SpriteRenderer.color = pickedColor;
	/*
		// Player Rotation
		if (Input.GetKey(right))
		{
			transform.Rotate(transform.forward, angle * -1.0f);
			transform.position += transform.right * Time.deltaTime * speed;
		}
		if (Input.GetKey(left))
		{
			transform.Rotate(transform.forward, angle);
			transform.position += transform.right * Time.deltaTime * speed;
		}
	*/

		//Change Sprites
		if (Input.GetAxis("Mouse Y") > 0)
		{
			m_SpriteRenderer.sprite = birdDown;
		}
		
		if (Input.GetAxis("Mouse Y") <= 0)
		{
			m_SpriteRenderer.sprite = birdUp;
		}


//		transform.LookAt(Input.mousePosition);
		// Pick Color
		if (Input.GetKeyDown(c_Btn1))
		{
			pickedColor = C_pink;
		}

		if (Input.GetKeyDown(c_Btn2))
		{
			pickedColor = C_blue;
		}

		if (Input.GetKeyDown(c_Btn3))
		{
			pickedColor = C_yellow;
		}

		if (Input.anyKey == false && transform.position.x != 0)
		{
			transform.position = Vector3.Lerp(transform.position, initialPos, Time.deltaTime);
		}
	}
}
