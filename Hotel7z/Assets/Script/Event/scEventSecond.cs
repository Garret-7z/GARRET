using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성자 : 우신현

public class scEventSecond : MonoBehaviour, iEvent {

    public scEventRunner Runner;

    // Use this for initialization
    void Start () {
        Runner.SetEvent(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Run()
    {
        Debug.Log("second 이벤트 실행 됨");
    }
    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
}
