using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEvt7th : MonoBehaviour, iEvent {

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        Debug.Log("11반 없애기!");
        /*
        DontDestroyOnLoad(Posi);
        Posi.transform.position = Player.transform.position;
        Posi.transform.rotation = Player.transform.rotation;
        SceneManager.LoadScene("EvtShinHyeon_no11");
        //Player = gameObject.transform.Find("Player").gameObject;
        Player.transform.position = Posi.transform.position;
        Player.transform.rotation = Posi.transform.rotation;
        */
    }
}
