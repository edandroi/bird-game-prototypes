using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class BulletManager : MonoBehaviour
{
	public GameObject bullet;

	public float timer;

	private Vector3 spawnPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			float newYPos = Random.Range(-4.5f, 4.5f);
			spawnPos = new Vector3(10f, newYPos, 0);
			Instantiate(bullet,spawnPos, Quaternion.identity);
			timer = Random.Range(1, timer);
		}
	}
}
