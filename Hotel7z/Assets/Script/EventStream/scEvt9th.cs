using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scEvt9th : MonoBehaviour, iEvent
{
    public GameObject Locker;
    public GameObject ShockBox;
    public GameObject Bag;


 


    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        Locker.GetComponent<scSetBool>().isLock = false;
        ShockBox.SetActive(true);
        Bag.SetActive(true);


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
