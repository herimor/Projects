using UnityEngine;
using System.Collections;

public class bazookaShout : MonoBehaviour {

	public Animator heroAnim;
	public Transform hero;
	public float shoutForce;
    public static bool fEnter = true;
	Rigidbody2D rigid;
	Animator animate;
    BoxCollider2D box;
	bool check = true, endAnim;
	float flipX = -0.25f, scaleX, startPos;

	void Start () {
		animate = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
        box = GetComponent<BoxCollider2D>();
		scaleX = transform.localScale.x;
	}

	void Update () {
		if (!heroController.die) {
			if (fEnter) {
				Flip ();
				transform.position = new Vector3 (hero.position.x + flipX, hero.position.y + 0.08f, -4f);
				transform.localScale = new Vector2 (scaleX, transform.localScale.y);
			}
			if (heroAnim.GetBool ("bazookaFire") && fEnter) {
				animate.SetBool ("fire", true);
                box.offset = new Vector2(0.15f, box.offset.y);
			}
			if (Mathf.Abs (transform.position.x - startPos) > 7f && !fEnter) {
				rigid.velocity = Vector2.zero;
				startPos = 0;
				fEnter = true;
				check = true;
                box.offset = new Vector2(0.05f, box.offset.y);
			}
			if (endAnim) {
				rigid.velocity = new Vector2 (shoutForce, rigid.velocity.y);
				endAnim = false;
			}
		}
	}
	void rocketStart()
	{
		startPos = transform.position.x;
		rigid.velocity = new Vector2 (shoutForce, rigid.velocity.y);
		fEnter = false;
	}
	void Flip(){
		if (heroController.isFasingRight && shoutForce < 0) {
			shoutForce *= -1;
			flipX *= -1;
			scaleX *= -1;
		} else if (!heroController.isFasingRight && shoutForce > 0) {
			shoutForce *= -1;
			flipX *= -1;
			scaleX *= -1;
		}
	}
	void ender(){
		animate.SetBool ("exploi", false);
		endAnim = true;
	}
	void replacer()
	{
		rigid.velocity = Vector2.zero;
		animate.SetBool("fire",false);
		animate.SetBool("exploi",true);
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "enemy" && !fEnter && check &&  Mathf.Abs(transform.position.x - col.gameObject.transform.position.x) < 0.8f) {
			rigid.velocity = Vector2.zero;
			animate.SetBool ("fire", false);
			animate.SetBool ("exploi", true);
			check = false;
		}
	}
}