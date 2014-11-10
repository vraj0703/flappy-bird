using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {

	void  OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			Debug.Log("here");
						Score.AddPoint ();
				}
		//gameObject.SetActive (false);

		}
}
