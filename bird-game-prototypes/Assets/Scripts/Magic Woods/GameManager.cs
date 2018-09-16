using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private TreeManager m_TreeManager;

	public int numOfMissedBirds;

	public int score;
	

	void Start ()
	{
		m_TreeManager = GameObject.Find("Tree Manager").GetComponent<TreeManager>();
	}
	

	void Update () {

		if (numOfMissedBirds > 6)
		{
			Debug.Log("You lost");
		}

		if (score > 12)
		{
			Debug.Log("You win!");
		}

	}
}
