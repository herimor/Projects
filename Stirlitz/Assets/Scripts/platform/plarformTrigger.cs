using UnityEngine;
using System.Collections;

public class plarformTrigger : MonoBehaviour {

	public Transform hero;
	BoxCollider2D box;
	bool lie,grounded;

	void Start () {
		box = GetComponent<BoxCollider2D> ();
	}

	void Update () {
		if (!heroController.die) {
			lie = heroController.lie;
			grounded = heroController.grounded;
			if (lie && grounded && (hero.position.y - transform.position.y) >= 0.6f) {  
				box.isTrigger = false;
			} else if ((hero.position.y - transform.position.y) >= 1f) {
				gameObject.layer = LayerMask.NameToLayer("Default");
				box.isTrigger = false;
			} else {
				gameObject.layer = LayerMask.NameToLayer("hero");
				box.isTrigger = true;
			}
		}
	}
}
