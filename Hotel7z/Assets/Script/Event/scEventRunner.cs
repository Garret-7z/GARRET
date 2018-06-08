using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성자 : 우신현

public class scEventRunner : MonoBehaviour {

    public enum EventStasis
        //이벤트 상태
    {
        COLLISION,
        TIME,
        LOGICCAL,
    }
    
    private List<iEvent> evts;
    [SerializeField]
    public GameObject[] Evts = null;
    public int evtidx;  //이벤트 인덱스 변수
    public bool MainEvent = true;  //메인 이벤트, 서브 이벤트 구분 변수

    public EventStasis eStasis;         //이벤트 상태
    
    public float TImer = 0;                 //타이머러너일때만 사용
    public bool isRunning;

    void Awake ()
    { 
        isRunning = false;
        evts = new List<iEvent>();
        for (int i = 0; i < Evts.Length; i++)
        {
            Evts[i].SendMessage("GetiEvent",this);
        }
    }
    public void SetUpEvt(object obj)
    {
        evts.Add(obj as iEvent);
    }
    void Start () { }
    void Update () {    }

    public void SetEvent(iEvent ev)
    {
        evts.Add(ev);
    }
    public void isRunEvent()
    {
        
        if (eStasis != EventStasis.LOGICCAL || evtidx != scGameManager.instance.eventIndex)
        {
            return;
        }
        RunAllEvent();

        if (MainEvent) //혁수 수정 : Logiccal때 GameManager의 EvtIndex 증가 하지 않아 추가함.
        { scGameManager.instance.eventIndex++; }

    }
    public void isTimerRun()
    {
        if (eStasis != EventStasis.TIME)
        {
            return;
        }
        StartCoroutine("TimerRun");
    }

    IEnumerator TimerRun()
    {
        float MaxTIme = TImer;

        while (MaxTIme > 0.0f)
        {
            MaxTIme -= Time.deltaTime;
            yield return null;
        }

        RunAllEvent();
    }
    void OnTriggerEnter(Collider coll)    //충돌처리
    {

        if (MainEvent && evtidx != scGameManager.instance.eventIndex)
        {
            return;
        }
       if (eStasis != EventStasis.COLLISION)
        {
            //gameObject.GetComponent<SphereCollider>().enabled = false;
            return;
        }
        Debug.Log("충돌하였음");
        
        Debug.Log(evtidx);
        Debug.Log(scGameManager.instance.eventIndex);
        RunAllEvent();

        if (MainEvent)
        { scGameManager.instance.eventIndex++; }
            
        Debug.Log("GameManager의 eventIndex : " + scGameManager.instance.eventIndex);
        Debug.Log("Runner의 evtidx : " + evtidx);
            
    }
    public void RunAllEvent()
    {
        if (isRunning) return;
        for (int i = 0; i < evts.Count; i++)
        {
            evts[i].Run();
        }
        isRunning = true;
    }
}

public interface iEvent
{
    void Run();
    void GetiEvent(object M);
    /*
     * 아래 코드 복사해서 iEvent에다가 붙여 넣으세요
     * public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }
     */
}
