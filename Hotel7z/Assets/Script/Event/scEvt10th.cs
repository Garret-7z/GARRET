using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEvt10th : MonoBehaviour, iEvent
{
    public scEventRunner Runner;
    public GameObject light;
    public scSound sound;

    public Animator Anim;
    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    void Start()
    {
        Runner.SetEvent(this);
    }

    public void Run()
    {
        light.SetActive(true);
        sound.Run();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "New Player" && Input.GetKeyDown(KeyCode.E))
        {
            Runner.isRunEvent();
        }
    }
}
