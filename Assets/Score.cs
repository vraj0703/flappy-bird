using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


	public static int score=0;
	public static int highscore;
	// Use this for initialization
	static Score instance;


	public static void AddPoint(){

		if (instance.bird.dead)
				return;

		score = score + 1;
		if(score>highscore)
			highscore=score;
		//score = score + 1;

	}

	BirdMovement bird;
	void Start()
	{
		
		score = 0;
		highscore = PlayerPrefs.GetInt ("highscore", 0);
		instance =this;
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		bird = player_go.GetComponent<BirdMovement> ();

	}
	void OnDestroy()
	{
		instance = null;
		PlayerPrefs.SetInt ("highscore", highscore);
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score + "\n" + "HighScore: " + highscore;
	}
}
