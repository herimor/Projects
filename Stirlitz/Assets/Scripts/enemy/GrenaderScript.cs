using UnityEngine;
using System.Collections;

public class GrenaderScript : MonoBehaviour
{

    public Animator animator;
    public Transform fire;
    public Transform hero;
    public Transform grena;
    BoxCollider2D box2D;
    Rigidbody2D rigy;
    Vector3 scale;
    float speed = 2f, coord = 0.5f, constX;
    bool isFacer = true, die, isTarget;
    public int health;
    public float distance;
    Animator anim;

    void Start()
    {
        box2D = GetComponent<BoxCollider2D>();
        constX = transform.position.x;
        rigy = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        deathMaybe();
        deatH();
        if (!die)
        {
            if (hero.position.y > transform.position.y - 0.8f && hero.position.x < transform.position.x + 4.1f && hero.position.x > transform.position.x - 4.1f &&
                hero.position.y < transform.position.y + 1.5f)
                targeT();
            else
            {
                isTarget = false;
                Moving();
            }
        }
    }
    void Moving()
    {
        anim.SetBool("stand", false);
        rigy.velocity = new Vector2(speed, rigy.velocity.y);
        if (!isTarget)
            Reverse();
    }
    void Reverse()
    {
        if (transform.position.x > constX + distance)
            Flip();
        if (transform.position.x < constX)
            Flip();
    }
    void Flip()
    {
        isFacer = !isFacer;
        scale.x *= -1;
        transform.localScale = scale;
        transform.position = new Vector3(transform.position.x - coord, transform.position.y, -3f);
        coord *= -1;
        speed *= -1;
        animator.SetBool("leftRight", isFacer);
    }
    void OnTriggerEnter2D(Collider2D col)
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
			box2D.size = new Vector2(box2D.size.x, 0.1f);
			box2D.offset = new Vector2(box2D.offset.x, -0.1f);
            box2D.isTrigger = true;
            heroController.score += 4;
            anim.SetBool("enemy_die", true);
            rigy.velocity = Vector2.zero;
            die = true;
        }
    }
    void ender()
    {
		Destroy (fire.gameObject);
        Destroy(gameObject);
    }
    void targeT()
    {
        isTarget = true;
        if (hero.position.y > (transform.position.y + 1f))
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
        //
        if (heroController.lie)
        {
            if (Mathf.Abs(hero.position.x - transform.position.x) < 0.8f)
            {
                //anim.SetBool("fire", false);
                anim.SetBool("stand", false);
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
            anim.SetBool("beat", false);
            if (!animator.GetBool("fire") && !animator.GetBool("exploi"))
            {
                anim.SetBool("stand", false);
                anim.SetBool("fire", true);
            }
            else
                anim.SetBool("stand", true);
            rigy.velocity = Vector2.zero;
        }
    }
    void beatHero()
    {
        heroController.health -= 5;
    }
    void fireGrenade()
    {
        anim.SetBool("fire", false);
        animator.SetBool("fire", true);
    }
    void deathMaybe()
    {
        if (!die && animator.GetBool("exploi") && Mathf.Abs(transform.position.x - grena.position.x) < 0.9f && Mathf.Abs(transform.position.y - grena.position.y) < 1.2f) 
        {
            health = 0;
        }
    }
    void beatHeroGrenade()
    {
        heroController.health -= 5;
    }
}
