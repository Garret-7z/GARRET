using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scInterObject : MonoBehaviour {
    private bool objOn = true;
    private Animator objAni;
    public GameObject InterObject;
	// Use this for initialization
	void Start () {
        objAni = InterObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play()
    {
        objAni.SetBool("objectState", objOn);
        objOn = !objOn;
    }
}
