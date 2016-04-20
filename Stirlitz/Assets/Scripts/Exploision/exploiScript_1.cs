using UnityEngine;
using System.Collections;

public class exploiScript_1 : MonoBehaviour {

	public static bool isExploi;
	Animator anim;
	
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "hero" && col.gameObject.name == "chick") {
			if (heroController.health <= 30)
				heroController.health = 0;
			else
				heroController.health -= 30;
			anim.SetBool ("exploi", true);
			chickScript.isExploi += 1f;	
		} else if (col.gameObject.name == "hero") {
			if (heroController.health <= 30)
				heroController.health = 0;
			else
				heroController.health -= 30;
			anim.SetBool ("exploi", true);
		}
	}
	void ender()
	{
		Destroy (gameObject);
	}
}
