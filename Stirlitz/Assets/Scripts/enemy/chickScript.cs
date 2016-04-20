using UnityEngine;
using System.Collections;

public class chickScript : MonoBehaviour {

	bool isFace;
	Vector3 scale;
	float speed = 3f,coord = 0.5f,time, constX;
	Rigidbody2D rigy;
	public static float isExploi;
	Animator animate;
	BoxCollider2D box;

	void Start () {
		constX = transform.position.x;
		box = GetComponent<BoxCollider2D> ();
		animate = GetComponent<Animator> ();
		rigy = GetComponent<Rigidbody2D> ();
		scale = transform.localScale;
	}

	void Update () {
		if (isExploi == 1f) {
			animate.SetFloat ("exploi", isExploi);
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.075f, -3f);
			box.size = new Vector2 (box.size.x, 0.24f);
			isExploi += 0.1f;
		} else if (isExploi >= 2f) {
			animate.SetFloat ("exploi", isExploi);
			rigy.velocity = Vector2.zero;
			speed = 0;
			time += Time.deltaTime;
			if (time >= 2)
				Destroy (gameObject);
			if(isExploi==2f)
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.03f, -3f);
		}
			rigy.velocity = new Vector2 (speed, rigy.velocity.y);
			if (transform.position.x < constX)
				Flip ();
			if (transform.position.x > constX + 9f)
				Flip ();
	}
	void Flip()
	{
		isFace = !isFace;
		scale.x *= -1;
		transform.localScale = scale;
		transform.position = new Vector3 (transform.position.x - coord, transform.position.y, -3f);
		coord *= -1;
		speed *= -1;
	}
}
