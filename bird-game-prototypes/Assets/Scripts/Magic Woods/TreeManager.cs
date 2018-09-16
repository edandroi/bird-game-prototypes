using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Timeline;

public class TreeManager : MonoBehaviour
{

	public GameObject treeObj;
	public GameObject birdObj;
	
	private float timer;
	
	public int numOfColors;

	public float speed;

	// Color Manager
	public ColorManager m_ColorManager;
//	Color32 C_pink = new Color32(250,38,148,250);
//	Color32 C_blue = new Color32(72,194,212,250);
	private Color32 C_pink;
	private Color32 C_blue;
	private Color32 C_red;
	
	// Use this for initialization
	void Start ()
	{
		timer = 1f;
		
		// Get the colors from Color Manager
		m_ColorManager = GameObject.Find("Color Manager").GetComponent<ColorManager>();
		C_pink = m_ColorManager.C_pink;
		C_blue = m_ColorManager.C_blue;
		C_red = m_ColorManager.C_red;

	}
	
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;

		// Time to instantiate trees
		if (timer < 0)
		{
			// Instantiate tree
			var newTree = Instantiate(treeObj, transform.position, Quaternion.identity) as GameObject;
			newTree.transform.parent = gameObject.transform;
			
			//Instantiate BIRDS
			Vector3 birdSpawnPos = newTree.transform.position + new Vector3(0, 1.5f, 0);
			var newBird = Instantiate(birdObj, birdSpawnPos, Quaternion.identity) as GameObject;
			newBird.transform.parent = newTree.transform;
			
			Color newBirdColor = new Color(0, 0, 0, 0);
			int colorNum = Random.Range(0, numOfColors);
			switch (colorNum)
             			{
             			case 0:
				             newBirdColor = C_pink;
             				break;
             			case 1 :
				             newBirdColor = C_blue;
             				break;
             			}
			newBird.GetComponent<SpriteRenderer>().color = newBirdColor;

			int destroyTheBird = Random.Range(0, 2);
			
			switch (destroyTheBird) 
			{
				case 0:
					Destroy(newBird);
					break;
				case 1:
					break;
			}
			
			//RESET TIMER
			timer = Random.Range(1, 2);

		}		
	}
	
	public void DestroyTrees(GameObject tree)
	{
		Destroy(tree);
	}

}
