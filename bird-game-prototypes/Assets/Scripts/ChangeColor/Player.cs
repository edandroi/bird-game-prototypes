using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

	public KeyCode forward;
	public KeyCode right;
	public KeyCode left;

	public float speed;
	public float angle;

	public Color pickedColor;
	public GameObject colorPicker;
	
	private SpriteRenderer m_SpriteRenderer;
	private Color m_NewColor;
	
	// Use this for initialization
	void Start () {
		colorPicker = GameObject.Find("Color Picker");
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		pickedColor = colorPicker.GetComponent<ColorPicker>().currentColor;
		m_SpriteRenderer.color = pickedColor;
		
		if (Input.GetKey(forward))
		{
			transform.position += transform.up * speed * Time.deltaTime;
		}

		if (Input.GetKey(right))
		{
			transform.Rotate(transform.forward, angle * -1.0f);
		}
		
		if (Input.GetKey(left))
		{
			transform.Rotate(transform.forward, angle);
		}
	}
}
