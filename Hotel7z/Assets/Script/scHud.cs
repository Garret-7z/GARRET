using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scHud : MonoBehaviour {
    private Text hudText;                // 텍스트
    private float objside;                  // 거리 계산
   // public bool interaction = false;        // 상호작용 on/off
    //public Transform interactionTr;        // 상호작용 받는 것의 위치 값 받아오는 변수
    private Transform playerTr;             // 플레이어의 위치 값을 받아오는 변수
    public MeshRenderer interactionMesh;   // 상호작용이 되면 Meshrenderer on
    //public BoxCollider playerRd;       // collider radius 값과 거리를 같게 해줄 변수
    public scDoor door;
    public bool doorOn = true;
    //private MeshCollider doorMesh;
    public bool doorLock = true;
   // public scInterObject interObject;
   // public bool objectOn=true;
    // Use this for initialization
    void Start()
    {
       
        //playerTr.GetComponent<Transform>();
        interactionMesh.GetComponent<MeshRenderer>().enabled = false;

        //playerRd.GetComponent<CapsuleCollider>(); 
        //성우야 성우야 성우야 성우야 성우야 성우야 성우야 성우야objside = playerRd.radius;
        //doorMesh.GetComponent<MeshCollider>();
        // hudText.GetComponent<Text>();
       // interactionMesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && interactionMesh.enabled != false && doorLock == false)
        {
            // interactionMesh.enabled = true;
            print("e눌림");
            
                // StartCoroutine (DoorCollider());
                if (doorOn == true)
                {
                    Debug.Log("bb");
                    door.SendMessage("Open");
                }
            
            /*if(objectOn == true)
            {
                interObject.SendMessage("Play");
            }
           
            /* else if(doorOn == true)
             {
               //  door.SendMessage("Close");
             }*/
        }

        /* float distance = Vector3.Distance(interactionTr.position, transform.position);
          if (distance + objside <= objside)
          */
        //Debug.Log(doorLock);
    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HUD TriggerStay :: GameOpject = " + this.gameObject.name);            
            interactionMesh.enabled = true;
            //door = col.GetComponent<scDoor>();
        }
       /* if (interactionMesh != false && oncol.gameObject.tag == "interaction"&& Input.GetKeyDown(KeyCode.E))
        {         
            print("e눌림");
                    }*/
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("HUD TriggerExit:: GameOpject = " + this.gameObject.name);
        interactionMesh.enabled = false;
      
    }
   /* IEnumerator DoorCollider() {
        doorMesh.convex = false;
        yield return new WaitForSeconds(1);
        doorMesh.convex = true;
    }*/

}
