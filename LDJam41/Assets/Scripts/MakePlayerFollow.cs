using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerFollow : MonoBehaviour {

    public Transform playerTransform;
    public float maxDistance = 50f;
    public float timeDiff = 60f;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

        timeDiff -= Time.deltaTime;
        if(timeDiff > 0)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) < maxDistance)
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                transform.position -= direction;
            }
        }


    }
}
