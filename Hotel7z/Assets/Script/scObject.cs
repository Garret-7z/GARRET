using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scObject : MonoBehaviour
{
    private Text hudText;                // 텍스트
    private float objside;                  // 거리 계산
    public float rotationSpeed = 10.0f;

    public float lerpSpeed = 1.0f;



   // public bool interaction = false;        // 상호작용 on/off
   // public Transform interactionTr;        // 상호작용 받는 것의 위치 값 받아오는 변수
    private Transform playerTr;             // 플레이어의 위치 값을 받아오는 변수
    public MeshRenderer interactionMesh;   // 상호작용이 되면 Meshrenderer on
    private CapsuleCollider playerRd;       // collider radius 값과 거리를 같게 해줄 변수
   // public scDoor door;
  //  public bool doorOn = false;
     public scInterObject interObject;
     public bool objectOn=true;
    private bool dragging = false;
    private Vector3 speed = new Vector3();

    private Vector3 avgSpeed = new Vector3();



   
    // Use this for initialization
    void Start()
    {
        
        playerTr.GetComponent<Transform>();
        interactionMesh.GetComponent<MeshRenderer>().enabled = true;

        playerRd.GetComponent<CapsuleCollider>();
        objside = playerRd.radius;

        // hudText.GetComponent<Text>();
        // interactionMesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && interactionMesh.enabled != false)
        {
            
            // interactionMesh.enabled = true;
            print("e눌림");
            scPlayer.play = !scPlayer.play;

            if (Input.GetMouseButton(0) && dragging)
            {

                speed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 2);

            }

            else
            {

                if (dragging)
                {

                    speed = avgSpeed;

                    dragging = false;

                }



                float i = Time.deltaTime * lerpSpeed;

                speed = Vector3.Lerp(speed, Vector3.zero, i);

            }



            transform.Rotate(Camera.main.transform.up * speed.x * rotationSpeed, Space.World);

            transform.Rotate(Camera.main.transform.right * speed.y * rotationSpeed, Space.World);



                 /* if (doorOn == false)
                  {

                      door.SendMessage("Open");
                  }*/
            if (objectOn == true)
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
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("?");
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
        Debug.Log("2");
        interactionMesh.enabled = false;

    }
    void OnMouseDown()
    {

        dragging = true;

    }



   

}
