using UnityEngine;
using System.Collections;

public class shutScript_1 : MonoBehaviour {
	//public AudioClip shoutt;
	public Transform hero;
	public float shout_force = 8f;
	public static int numbeR = 1;
	public static bool fEnter = true;
	Animator anim;
	Rigidbody2D rigy;
	float save_pos;
	bool secEnter,die, check,afterAimFlight;
	float flip_x = 0.5f, scaleX;

	void Start () {
		anim = GetComponent<Animator> ();
		rigy = GetComponent<Rigidbody2D> ();
		scaleX = transform.localScale.x;
	}

	void Update () {
		die = heroController.die;
		if (!die && heroController.Gun == "pistols") {
			Flip ();
			if (fEnter) {
				transform.position = new Vector3 (hero.position.x + flip_x, hero.position.y, -4f);
				transform.localScale = new Vector2 (scaleX, transform.localScale.y);
			}
			if (Input.GetKey (KeyCode.F) && numbeR == 2 && fEnter) {
				anim.SetBool ("aim", false);
				anim.SetBool ("shout", true);
				save_pos = Mathf.Abs (hero.position.x + flip_x);
				secEnter = true;
			} else if (Mathf.Abs (Mathf.Abs (transform.position.x) - save_pos) > 1.5f && secEnter) {
				numbeR = 3;
				shout_2Script.numbeR = numbeR;
				secEnter = false;
			} else if (Mathf.Abs (Mathf.Abs (transform.position.x) - save_pos) > 8f && !fEnter) {
				anim.SetBool ("shout", false);
				rigy.velocity = new Vector2 (0f, rigy.velocity.y);
				save_pos = 0;
				fEnter = true;
				check = false;
			} else if (afterAimFlight) {
				rigy.velocity = new Vector2 (shout_force, rigy.velocity.y);
				afterAimFlight = false;
			}
		}
	}

	void Flip(){
		if (heroController.isFasingRight && shout_force < 0) { 
			shout_force *= -1;
			flip_x = 0.5f;
			scaleX *= -1;
		} else if (!heroController.isFasingRight && shout_force > 0) {
			shout_force *= -1;
			flip_x = -0.5f;
			scaleX *= -1;
		}
	}
	void mainF()
	{
		rigy.velocity = new Vector2 (shout_force, rigy.velocity.y);
		fEnter = false;
		//AudioSource.PlayClipAtPoint (shoutt, transform.position, 0.3f);
	}
	void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.tag == "enemy" && !fEnter && !check)
        {
			rigy.velocity = Vector2.zero;
			anim.SetBool ("aim", true);
			check = true;
		}
	}
	void Ender()
	{
		anim.SetBool ("shout", false);
		anim.SetBool ("aim", false);
		afterAimFlight = true;
	}
}