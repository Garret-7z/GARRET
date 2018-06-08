using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventexample : MonoBehaviour ,iEvent
{
    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
    Transform Tr;
    public Vector3 Pos;

    public void Start()
    {
        Tr = transform;
    }
    public void Run()
    {
        Tr.position = Pos;
    }
}
