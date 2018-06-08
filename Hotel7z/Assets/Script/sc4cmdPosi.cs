using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc4cmdPosi : MonoBehaviour {

    public GameObject Player;
    public GameObject Posi;

	// Use this for initialization
	void Start ()
    {
        Posi = gameObject.transform.Find("PlayerPosi").gameObject;
        Player.transform.position = Posi.transform.position;
        Player.transform.rotation = Posi.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
