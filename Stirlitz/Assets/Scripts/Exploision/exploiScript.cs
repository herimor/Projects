using UnityEngine;
using System.Collections;

public class exploiScript : MonoBehaviour {

	public AudioClip bang;
	public static bool isExploi;
	public Transform chick;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "hero" && Mathf.Abs(chick.position.x - transform.position.x) < 0.6f){
			if (heroController.health <= 30)
				heroController.health = 0;
			else
				heroController.health -= 30;
			anim.SetBool ("exploi", true);
			chickScript.isExploi += 1f;	
			AudioSource.PlayClipAtPoint (bang, transform.position, 0.3f);
		} else if (col.gameObject.name == "hero") {
			if (heroController.health <= 30)
				heroController.health = 0;
			else
				heroController.health -= 30;
			anim.SetBool ("exploi", true);
			AudioSource.PlayClipAtPoint (bang, transform.position, 0.3f);
		}
	}
	void ender()
	{
		Destroy (gameObject);
	}
}
