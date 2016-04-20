using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target, borderL,borderR, borderTop;

	void Start () {
	}

	void Update () {
		if (Mathf.Abs (target.position.x - borderL.position.x) < 4f && borderTop.position.y - target.position.y < 1f)        //left_Top
			targeT (borderL.position.x + 4.6f,borderTop.position.y);
		else if (Mathf.Abs (target.position.x - borderR.position.x) < 6f && borderTop.position.y - target.position.y < 1f)   //right_Top
			targeT (borderR.position.x - 4.6f,borderTop.position.y);
		else if (Mathf.Abs (target.position.x - borderL.position.x) < 4f)                                                     //left
			targeT (borderL.position.x + 4.6f,target.position.y + 0.5f);
		else if (Mathf.Abs (target.position.x - borderR.position.x) < 6f)                                                     //right
			targeT (borderR.position.x - 4.6f,target.position.y + 0.5f);
		else if(borderTop.position.y - target.position.y < 1f)                                                                //top
			targeT (target.position.x + 0.5f,borderTop.position.y);
		else                                                                                                                  //all another
			targeT (target.position.x + 0.5f,target.position.y + 0.5f);                                                        
	}
	void targeT(float deltaX, float deltaY){
		Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (new Vector3 (target.position.x, target.position.y + 2f, target.position.z));
		Vector3 delta = new Vector3 (deltaX, deltaY, target.position.z) - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
		Vector3 destination = transform.position + delta;	
		transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
	}
}
