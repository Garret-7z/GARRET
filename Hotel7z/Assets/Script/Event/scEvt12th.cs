using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEvt12th : MonoBehaviour, iEvent
{
    public scEventRunner Runner;
    public GameObject[] Light;
    public int msgIndex;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    void Start ()
    {
        Runner.SetEvent(this);
    }

    public void Run()
    {
        for (int i = msgIndex; i >= msgIndex - 1; i --)
        {
            try
            {
                if (scMsg.msgList.Contains(scMsg.msgList[msgIndex]))
                {
                    scMsg.DeleteMessage(msgIndex);
                }
            }
            catch (Exception e) { }
        }

        Light[0].SetActive(false);
        Light[1].SetActive(true);
    }
}
