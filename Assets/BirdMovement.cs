 using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

//	Vector3 velocity =Vector3.zero;
	public float flapSpeed=50f;
	Vector2 forwardSpeed= Vector2.one;

	bool didFlap=false;
	Animator animator;
	public bool dead=false;

	public bool godMode=false;
	float deathCoolDown;


	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator> ();
		if (animator == null) {
			Debug.LogError("hai");
				}

	}
	
	// Update is called once per frame
	void Update () {


		if (dead) {
						deathCoolDown -= Time.deltaTime;
			if((deathCoolDown<=0))
			   if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)||Input.touchCount==1) 
					Application.LoadLevel(Application.loadedLevel);
				}
		else
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)||Input.touchCount==1) {
				didFlap=true;		
		}
	}
	void FixedUpdate()
	{
				if (dead)
						return;
				rigidbody2D.AddForce ( forwardSpeed);
				if (didFlap) {
			rigidbody2D.AddForce (Vector2.up * flapSpeed);
			//animator.SetTrigger("flap");
			animator.SetTrigger ("Here");
			didFlap = false;
				}
				if (rigidbody2D.velocity.y > 0)
						transform.rotation = Quaternion.Euler (0, 0, 0);
				else {
						float angle = Mathf.Lerp (0, -90, (-rigidbody2D.velocity.y / 3f));
						transform.rotation = Quaternion.Euler (0, 0, angle);
				}
		}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (godMode)
						return;
		animator.SetTrigger ("done");
		dead = true;
		deathCoolDown = .5f;
		}
}
