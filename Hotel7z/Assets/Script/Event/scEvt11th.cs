using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEvt11th : MonoBehaviour, iEvent
{
    public scEventRunner Runner;
    public GameObject light;
    public string Msg;

    private int MsgCount = 0;
    private int eventCount = 0;

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    void Start ()
    {
        Runner.SetEvent(this);
    }

    void Update()
    {
        if (scGameManager.instance.eventIndex == 12)
        {
            if (eventCount < 3)
            {
                Runner.isRunning = false;
            }
            else if (eventCount == 3)
            {
                scGameManager.instance.eventIndex = -3;
            }
        }
    }

    public void Run()
    {
        ++eventCount;
        if (scGameManager.instance.eventIndex == 12)
        {
            if (eventCount < 3) scMsg.CreateNewMessage(Msg);
            Msg = "기다려";
            Runner.isTimerRun();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (MsgCount == 0 && scGameManager.instance.eventIndex == Runner.evtidx)
            {
                MsgCount++;
                scGameManager.instance.eventIndex++;

                scMsg.CreateNewMessage("11반으로 와라. 3분");
                light.SetActive(true);

                Runner.isTimerRun();
            }
        }
    }
}
