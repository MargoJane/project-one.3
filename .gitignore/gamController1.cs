using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamController1 : MonoBehaviour {
	int bronzeOre;
	int silverOre;
	int timeToMine;
	int miningSpeed;
	int bronzeSupply;
	int silverSupply;
	Vector3 cubePosition;
	GameObject currentCube;
	float xPosition;
	public GameObject Cube;


	// Use this for initialization
	void Start () {
		bronzeOre= 0;
		silverOre= 0;
		bronzeSupply = 3;
		silverSupply= 2;
		miningSpeed= 3;

		timeToMine= miningSpeed;

		cubePosition = new Vector3 (0f,0f,0f);

		xPosition = 0f;
	}

	// Update is called once per frame
	void Update () {
		//Mine for Bronze
		if (Time.time > timeToMine) {
			if (bronzeSupply >= 1) {
				bronzeSupply -= 1;
				bronzeOre += 1;

				cubePosition = new Vector3 (xPosition, 0f, 0f);
				currentCube= Instantiate(Cube, cubePosition, Quaternion.identity);
				currentCube.GetComponent<Renderer>().material.color = Color.red;

				xPosition += 5;

			}
			//Mine for silver after bronze is gone
			else if (bronzeSupply == 0 && silverSupply >= 1) {
				silverSupply -= 1;
				silverOre += 1;

				cubePosition = new Vector3 (xPosition, 0f, 0f);
				currentCube= Instantiate(Cube, cubePosition, Quaternion.identity);
				currentCube.GetComponent<Renderer>().material.color = Color.gray;

				xPosition += 5;
			}
			timeToMine += miningSpeed;

			print("Bronze: " + bronzeOre);
			print("Silver: " + silverOre);
		}
	}
}
