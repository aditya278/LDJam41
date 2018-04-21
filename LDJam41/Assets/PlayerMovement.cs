using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Vector3 direction;
	public float h;
	public float v;
	public float angle;
	// Use this for initialization
	void Start () {
		direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		direction = new Vector3 (h, v);

		gameObject.transform.position += direction * 0.05f;


		angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
