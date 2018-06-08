using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEvt6th : MonoBehaviour, iEvent
{
    public GameObject back6;
    public GameObject back8;
    public GameObject light8;
    public GameObject evt5;
    public GameObject pigDie;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        //doorAni.SetBool("doorState", dOn);
        //dOn = !dOn;
        back6.SendMessage("Open");
        back8.SendMessage("Open");
        light8.SetActive(true);
        evt5.SetActive(false);
        pigDie.SetActive(true);
        
    }
}
