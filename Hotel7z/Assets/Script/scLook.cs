using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scLook : MonoBehaviour {
    public Transform target;
    private Vector3 targetPosition;

    
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);

        this.transform.LookAt(targetPosition);



    }
}
