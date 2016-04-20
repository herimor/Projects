using UnityEngine;
using System.Collections;

public class grenadeScript : MonoBehaviour
{

    Rigidbody2D rigid;
    Animator animator;
    public Transform enemy;
    bool fEnter = true, endEdit;
    int round;
    float velocX, flipX;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animator.GetBool("die"))
        {
            if (fEnter)
            {
                flip();
                transform.position = new Vector3(enemy.position.x + flipX, enemy.position.y + 0.6f, -4f);
            }
            if (animator.GetBool("fire"))
            {
                rigid.velocity = new Vector2(velocX, -1f);
                fEnter = false;
            }
            if (endEdit)
            {
                fEnter = true;
                endEdit = false;
            }
        }
    }
    void flip()
    {
        if (animator.GetBool("leftRight"))
        {
            velocX = 3f;
            transform.localScale = new Vector2(-5, 5);
            flipX = 0.6f;
        }
        else
        {
            velocX = -3f;
            transform.localScale = new Vector2(5, 5);
            flipX = -0.6f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "enemy" && animator.GetBool("fire"))
        {
            rigid.velocity = Vector2.zero;
            animator.SetBool("fire", false);
            animator.SetBool("exploi", true);
        }
    }
    void enderAnim()
    {
        animator.SetBool("exploi", false);
        round = 0;
        endEdit = true;
    }
    void roundRound()
    {
        if (round == 2)
        {
            rigid.velocity = Vector2.zero;
            animator.SetBool("fire", false);
            animator.SetBool("exploi", true);
            round = 0;
        }
        else
            round++;
    }
}
