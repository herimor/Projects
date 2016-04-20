using UnityEngine;
using System.Collections;

public class enemyScript_1 : MonoBehaviour {

	Rigidbody2D rigy;
	Vector3 scale;
	Animator anim;
	BoxCollider2D box2D;
	float speed = 2f, coord = 0.5f, border1Copy, border2Copy;
    bool isFacer = true, die, sit_morz, isTarget;
	public float border1, border2;
	public int health = 3;
	public Transform hero;
	public Animator animator;
	public Transform morza_transf;
	public bool isRightMorza;
	
	void Start () {
		box2D = GetComponent<BoxCollider2D> ();
		rigy = GetComponent<Rigidbody2D> ();
		scale = transform.localScale;
		anim = GetComponent<Animator> ();
	}
	void Update () {
		deatH ();
		if (!die) {
			if (Mathf.Abs (hero.position.y - transform.position.y) < 1f && hero.position.x > (border1 - 2.5f) && hero.position.x < (border2 + 2.5f)) {
				if (Mathf.Abs (hero.position.x - transform.position.x) < 3f)
					targeT ();
				else {
					isTarget = false;
					Moving ();
				}
			} else if (Mathf.Abs (hero.position.x - transform.position.x) < 3f && Mathf.Abs (hero.position.y - transform.position.y) < 1f)
				targeT ();
			else {
				isTarget = false;
				Moving ();
				morza ();
			}
		}
	}
    void Moving()
    {
		anim.SetBool ("beat", false);
		anim.SetBool ("morza", false);
		anim.SetBool ("fire", false);
		sit_morz = false;
		transform.position = new Vector3 (transform.position.x, morza_transf.position.y - 0.165f, -3f);
		rigy.velocity = new Vector2 (speed, rigy.velocity.y);
		if (!isTarget)
			Reverse ();
	}
    void Reverse()
    {
        reverseHelper();
        if (transform.position.x > border2)
            Flip();
        if (transform.position.x < border1)
            Flip();
    }
    void reverseHelper()
    {
		while (transform.position.x - Mathf.Abs(coord) > border2) {
			if (border2Copy == 0)
				border2Copy = border2;
			border2++;
		}
		while (transform.position.x + Mathf.Abs(coord) < border1) {
			if (border1Copy == 0)
				border1Copy = border1;
			border1--;
		}
		if (transform.position.x < border2Copy && border2Copy != 0) {
			border2 = border2Copy;
			border2Copy = 0;
		} else if (transform.position.x > border1Copy && border1Copy != 0) {
			border1 = border1Copy;
			border1Copy = 0;
		}
	}
	void Flip()
	{
		isFacer = !isFacer;
		scale.x *= -1;
		transform.localScale = scale;
		transform.position = new Vector3 (transform.position.x - coord, transform.position.y, -3f);
		coord *= -1;
		speed *= -1;
		anim.SetBool ("isFacingRight", isFacer);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "shout" && !shoutScript.fEnter) 
			health--;
		else if (col.gameObject.name == "shout_1" && !shutScript_1.fEnter)
			health--;
		else if (col.gameObject.name == "shout_2" && !shout_2Script.fEnter)
			health--;
		else if (col.gameObject.name == "shout_3" && !shout_3Script.fEnter)
			health--;
		if (col.gameObject.name == "shoutGun" && !bazookaShout.fEnter) 
			health = 0;
	}
	void deatH(){
		if (health == 0 && !die) {
			box2D.size = new Vector2(box2D.size.x, 0.1f);
			box2D.offset = new Vector2(box2D.offset.x, -0.1f);
			box2D.isTrigger = true;
			heroController.score += 4;
			anim.SetBool ("enemy_die",true);
			rigy.velocity = Vector2.zero;
			die = true;
		}
	}
	void ender(){
		Destroy (animator.gameObject);
		Destroy (gameObject);
	}
	void morza(){
		if (transform.position.x - morza_transf.position.x + 0.3f > 0.3f && !sit_morz && isRightMorza) {   
			rigy.velocity = Vector2.zero;
			if (isFacer)
				Flip ();
			transform.position = new Vector3 (morza_transf.position.x + 0.4f, morza_transf.position.y - 0.225f, -3f); 
			anim.SetBool ("morza", true);
			sit_morz = true;
		}else if (morza_transf.position.x - transform.position.x + 0.3f > 0.3f && !sit_morz && !isRightMorza) {   
			rigy.velocity = Vector2.zero;
			if (!isFacer)
				Flip ();
			transform.position = new Vector3 (morza_transf.position.x - 0.4f, morza_transf.position.y - 0.225f, -3f); 
			anim.SetBool ("morza", true);
			sit_morz = true;
		}
	}
    void targeT()
    {
        isTarget = true;
        if (hero.position.y > (transform.position.y + 1.2f))
            box2D.isTrigger = true;
        else
            box2D.isTrigger = false;
        //
        if (hero.position.x + 0.5f < transform.position.x && isFacer)
        {
            Flip();
        }
        else if (hero.position.x - 0.5f > transform.position.x && !isFacer)
        {
            Flip();
        }
        if (heroController.lie)
        {
            if (Mathf.Abs(hero.position.x - transform.position.x) < 0.8f)
            {
                anim.SetBool("fire", false);
                anim.SetBool("beat", true);
                rigy.velocity = Vector2.zero;
            }
            else
            {
                anim.SetBool("beat", false);
                Moving();
            }
        }
        else
        {
            sit_morz = false;
			anim.SetBool("morza", false);
            anim.SetBool("beat", false);
            anim.SetBool("fire", true);
            if (!animator.GetBool("fire_dist"))
                animator.SetBool("fire", true);
            rigy.velocity = Vector2.zero;
        }
    }
	void beatHero()
	{
		heroController.health -= 5;
	}
}