using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels=6;
	float maxHieght=7.198205f;
	float minHieght=4.363109f;

	// Use this for initialization
	//public bool godMode=false;

	void Start(){
				GameObject[] pipes = GameObject.FindGameObjectsWithTag ("pipe");
				foreach (GameObject pipe in pipes) {
						Vector3 pos = pipe.transform.position;
						pos.y=Random.Range(minHieght,maxHieght);
						pipe.transform.position = pos;
				}
		}
	void OnTriggerEnter2D(Collider2D collider)
	{
				float widthOFBGobject = ((BoxCollider2D)collider).size.x;
				Vector3 pos = collider.transform.position;
				pos.x += widthOFBGobject * numBGPanels;
				if (collider.tag == "pipe") {
					pos.y=Random.Range(minHieght,maxHieght);
				}
				collider.transform.position = pos;
		}
}


