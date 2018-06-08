using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scGameManager : MonoBehaviour {
    public static scGameManager instance;
    public int eventIndex;
    void Awake()
    {
        eventIndex = 0;
        instance = this;
    }
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
