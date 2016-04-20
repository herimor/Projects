using UnityEngine;
using System.Collections;

public class docsCollect : MonoBehaviour {

	public AudioClip doc;
	public GUIText docs;
	public static int howMuch;
	Animator animate;
	bool isFirst = true;

	void Start () {
		animate = GetComponent<Animator> ();
		docs.text = "" + howMuch;
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "hero" && isFirst) {
			howMuch--;
			heroController.score += 2;
			docs.text = "" + howMuch; 
			AudioSource.PlayClipAtPoint (doc, transform.position, 0.3f);
			transform.position = new Vector2 (transform.position.x, transform.position.y + 0.6f);
			animate.SetBool ("isCollect", isFirst);
			isFirst = false;
		}
	}

	void Ended()
	{
		Destroy (gameObject);
	}
}
