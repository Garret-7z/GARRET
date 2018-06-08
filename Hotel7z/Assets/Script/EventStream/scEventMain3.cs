using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEventMain3 : MonoBehaviour , iEvent {

    public static int EventCount = 0;
    scSound sound1;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

      

    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(" 스테이 들어옴   ");
        if (Input.GetKeyDown(KeyCode.E) && EventCount ==0 && col.gameObject.tag == "Player")
        {
            Debug.Log("Player 접촉 확인 완료   ");
            EventCount++;
            Debug.Log("EventCount : " + EventCount);
            sound1.Run();
        }
    }

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        
    }
}
