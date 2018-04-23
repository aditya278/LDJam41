using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerFollow : MonoBehaviour {

    public Transform playerTransform;
    public float maxDistance = 50f;
    public float timeDiff = 120f;
	// Use this for initialization
	void Start () {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        timeDiff -= Time.deltaTime;
        if(timeDiff > 0)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) < maxDistance)
            {
                if (transform.position.x > 22f && transform.position.x < 278f)
                {
                    if (transform.position.y > 22f && transform.position.y < 278f)
                    {
                        Vector3 direction = (playerTransform.position - transform.position).normalized;
                        transform.position -= direction;
                    }
                }
            }
        }


    }
}
