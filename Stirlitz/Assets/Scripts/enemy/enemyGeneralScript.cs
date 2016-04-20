using UnityEngine;
using System.Collections;

public class enemyGeneralScript : MonoBehaviour
{

    public Animator animator;
    public Transform hero;
    BoxCollider2D box2D;
    Rigidbody2D rigy;
    Vector3 scale;
    float speed = 2f, coord = 0.5f, constX, timeR, constXcopy, distanceCopy;
	public bool isPlatform;
    bool isFacer = true, die, isTarget;
    public int health;
    public float distance;
    Animator anim;
    public float startTime;

    void Start()
    {
        box2D = GetComponent<BoxCollider2D>();
        constX = transform.position.x;
        rigy = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        anim = GetComponent<Animator>();
        anim.SetBool("isFacingRight", isFacer);
    }
    void Update()
    {
		if (timeR < startTime)
			timeR += Time.deltaTime;
		else {
			deatH ();
			if (!die) {
				if (Mathf.Abs (hero.position.y - transform.position.y) < 0.9f && Mathf.Abs (hero.position.x - transform.position.x) < 4f)
					targeT ();
				else {
					isTarget = false;
					Moving ();
				}
			}
		}
	}
    void Moving()
    {
        anim.SetBool("fire", false);
        rigy.velocity = new Vector2(speed, rigy.velocity.y);
        if (!isTarget)
            Reverse();
    }
    void Reverse()
    {
        reverseHelper();
        if (transform.position.x > constX + distance)
            Flip();
        if (transform.position.x < constX)
            Flip();
    }
    void reverseHelper()
    {
        if (!isPlatform)
        {
            while (transform.position.x - Mathf.Abs(coord) > constX + distance)
            {
                if (distanceCopy == 0)
                    distanceCopy = distance;
                distance++;
            }
            while (transform.position.x + Mathf.Abs(coord) < constX)
            {
                if (constXcopy == 0)
                    constXcopy = constX;
                constX--;
            }
            if (transform.position.x < constX + distanceCopy && distanceCopy != 0)
            {
                distance = distanceCopy;
                distanceCopy = 0;
            }
            if (transform.position.x > constXcopy && constXcopy != 0)
            {
                constX = constXcopy;
                constXcopy = 0;
            }
        }
    }
    void Flip()
    {
        isFacer = !isFacer;
        scale.x *= -1;
        transform.localScale = scale;
        transform.position = new Vector3(transform.position.x - coord, transform.position.y, -3f);
        coord *= -1;
        speed *= -1;
        anim.SetBool("isFacingRight", isFacer);
    }
    void OnTriggerExit2D(Collider2D col)
    {
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
    void deatH()
    {
        if (health == 0 && !die)
        {
            box2D.isTrigger = true;
			box2D.size = new Vector2(box2D.size.x,0.1f);
			box2D.offset = new Vector2(box2D.offset.x,-0.1f);
            heroController.score += 4;
            anim.SetBool("enemy_die", true);
            rigy.velocity = Vector2.zero;
            die = true;
        }
    }
    void ender()
    {
		Destroy (animator.gameObject);
        Destroy(gameObject);
    }
    void targeT()
    {
		isTarget = true;
		if (hero.position.y > (transform.position.y + 1.2f))
			box2D.isTrigger = true;
		else
			box2D.isTrigger = false;
		//
		if (hero.position.x + 0.5f < transform.position.x && isFacer) {
			Flip ();
		} else if (hero.position.x - 0.5f > transform.position.x && !isFacer) {
			Flip ();
		}
		//
		if (heroController.lie) {
			if (Mathf.Abs (hero.position.x - transform.position.x) < 0.8f) {   
				anim.SetBool ("fire", false);
				anim.SetBool ("beat", true);
				rigy.velocity = Vector2.zero;
			} else if (!isPlatform) {
				anim.SetBool ("beat", false);
				Moving ();
			} else if (isPlatform) {
				anim.SetBool ("beat", false);
				anim.SetBool ("fire", true);
				if (!animator.GetBool ("fire") && !animator.GetBool ("fire_dist"))  
					animator.SetBool ("fire", true);
				rigy.velocity = Vector2.zero;
			}
		} else {
			anim.SetBool ("beat", false);
			anim.SetBool ("fire", true);
			if (!animator.GetBool ("fire_dist"))
				animator.SetBool ("fire", true);
			rigy.velocity = Vector2.zero;
		}
	}
    void beatHero()
    {
        heroController.health -= 5;
    }
}
