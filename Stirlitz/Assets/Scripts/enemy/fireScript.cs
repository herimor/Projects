using UnityEngine;
using System.Collections;

public class fireScript : MonoBehaviour {

	//public AudioClip shoutt;
	public Transform enemy;
	public Animator animator;
	bool isShot,fEnter = true, check, afterAimFlight;
	float shoutForce = 5f, save_pos, flip_x, fire_direct, koff;
	Animator anim;
	Rigidbody2D rigy;
	Vector2 startShoutSide;

	void Start () {
		anim = GetComponent<Animator> ();
		rigy = GetComponent<Rigidbody2D> ();
		startShoutSide = new Vector2 (transform.localScale.x, transform.localScale.y);
	}

	void Update () {
		if (!animator.GetBool ("enemy_die")) {
			if (fEnter) {
				flip (animator.GetBool ("isFacingRight"));
				transform.position = new Vector3 (enemy.position.x + flip_x, enemy.position.y + 0.05f, -4f);
				anim.SetBool ("fire_dist", false);
				shoT ();
			} else if (Mathf.Abs (Mathf.Abs (transform.position.x) - save_pos) > 4f && !fEnter) {
				anim.SetBool ("fire", false);
				rigy.velocity = Vector2.zero;
				save_pos = 0;
				fEnter = true;
				check = false;
			}
			if (afterAimFlight) {
				rigy.velocity = new Vector2 (shoutForce, rigy.velocity.y);
				afterAimFlight = false;
			}
		}
	}
	void flip(bool isFacingRight)
	{
		if (isFacingRight)
			koff = 1f;
		else
			koff = -1f;
		flip_x = 0.6f * koff;
		shoutForce = 5f * koff;
		transform.localScale = startShoutSide * koff;
	}
	void shoT(){
		if (anim.GetBool("fire")) {
			//AudioSource.PlayClipAtPoint (shoutt, transform.position, 0.1f);
			save_pos = Mathf.Abs (enemy.position.x + flip_x);
			fEnter = false;
		}
	}
	void Ender() {
		anim.SetBool ("fire_aim", false);
		afterAimFlight = true;
	}
	void mainF() {
		rigy.velocity = new Vector2 (shoutForce, rigy.velocity.y);
		anim.SetBool ("fire_dist", true);
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.name == "hero" && !check && !fEnter) {
			rigy.velocity = Vector2.zero;
			anim.SetBool ("fire", false);
			anim.SetBool ("fire_aim", true);
			heroController.health -= 5;
			anim.SetBool ("fire_dist", true);
			check = true;
		}
	}
}
