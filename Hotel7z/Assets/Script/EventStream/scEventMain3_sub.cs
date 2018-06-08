using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scEventMain3_sub : MonoBehaviour, iEvent
{
    public scHud opendoor;
    public TextMesh TextMeshopen;
    public  MeshRenderer PressTab;
    public scSound sound1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E) && scEventMain3.EventCount == 1 && col.gameObject.tag == "Player")
        {
            //scMsg.CreateNewMessage("문자_1수신");
            //Debug.Log("2 == EventCount : 문자수신됨 ");
            //Run();
        }
    }

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

    public void Run()
    {
        Debug.Log("2 == EventCount : 문자수신됨 ");
        sound1.audioPlayer.Play(); // 문자 올떄마다 이딴식으로 코드 넣어줘야함 메시지 안에 구현해볼려고 했는데 걍 이렇게 해야할듯 ㅠㅠ
        scMsg.CreateNewMessage("6반으로 와");
        opendoor.doorLock = false;
        TextMeshopen.text = "Press E";
        PressTab.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(press());
    }

    IEnumerator press()
    {
        yield return new WaitForSeconds(5.0f);
        PressTab.GetComponent<MeshRenderer>().enabled = false;

    }
      
 
      
    
}
