using UnityEngine;
using System.Collections;

public class elevatorScript : MonoBehaviour
{

    Rigidbody2D rigid;
    BoxCollider2D boxCol;
    Vector2 velocUp;
    public Transform hero;
    public Animator heroAnim;
    public float top, bottom;
    float timeR, impuls = 0.05f, triggY;
	bool check;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        velocUp = new Vector2(velocUp.x, 1.5f);
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
	{
		if (timeR < 2f) {
			timeR += Time.deltaTime;
			check = true;
		}
		else {
			if(check){
				transform.position = new Vector2 (transform.position.x, transform.position.y + impuls);
				check = false;
			}
            triggerFunc();
			elevate ();
		}
	}
    void triggerFunc()
    {
        if (heroAnim.GetBool("lie") || heroAnim.GetBool("lie_go"))
            triggY = -0.25f;
        else
            triggY = -0.7f;
        if (transform.position.y > hero.position.y + triggY)
            boxCol.isTrigger = true;
        else
            boxCol.isTrigger = false;
    }
    void elevate()
    {
        if (transform.position.y > top - 0.03f)
        {
            reversePause(top);
			timeR = 0;
        }
        else if (transform.position.y < bottom + 0.03f)
        {
            reversePause(bottom);
			timeR = 0;
        }
        else
            rigid.velocity = velocUp;
    }

    void reversePause(float posY)
    {
        rigid.velocity = Vector2.zero;
		velocUp *= -1;
		impuls *= -1;
        transform.position = new Vector2(transform.position.x, posY);
    }
}
