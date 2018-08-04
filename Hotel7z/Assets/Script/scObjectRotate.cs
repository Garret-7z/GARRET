//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class scObjectRotate : MonoBehaviour
//{
//    private float objside;
//    private Transform playerTr;             // 플레이어의 위치 값을 받아오는 변수
//    public MeshRenderer interactionMesh;   // 상호작용이 되면 Meshrenderer on
//    private CapsuleCollider playerRd;

//    public float rotationSpeed = 10.0f;

//    public float lerpSpeed = 1.0f;

//    private bool jh = false;

//    private Vector3 speed = new Vector3();

//    private Vector3 avgSpeed = new Vector3();

//    private bool dragging = false;

//    void Start()
//    {
//        playerTr.GetComponent<Transform>();
//        interactionMesh.GetComponent<MeshRenderer>().enabled = true;

//        playerRd.GetComponent<CapsuleCollider>();

//        objside = playerRd.radius;
//    }

//    void OnMouseDown()
//    {

//        dragging = true;

//    }



//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E) && interactionMesh.enabled != false)
//        {
//            scPlayer.play = !scPlayer.play;
//            jh = !jh;
//            Debug.Log(jh);
//        }

//        if (jh)
//        {

//            if (Input.GetMouseButton(0) && dragging)
//            {

//                speed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

//                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 1);

//                rotationSpeed = 5;
               
//            }

//            else
//        {
//                rotationSpeed = 0;
//                if (dragging)
//                {

//                    speed = avgSpeed;

//                    dragging = false;

//                }




//                float i = Time.deltaTime * lerpSpeed;

//                speed = Vector3.Lerp(speed, Vector3.zero, i);


//            }


//        }
//        transform.Rotate(Camera.main.transform.up * speed.x * rotationSpeed, Space.World);

//        transform.Rotate(Camera.main.transform.right * speed.y * rotationSpeed, Space.World);

//    }

//    void OnTriggerEnter(Collider col)
//    {

//        if (col.gameObject.tag == "Player")
//        {
           
//            interactionMesh.enabled = true;
//            //door = col.GetComponent<scDoor>();
//        }




//    }
//    void OnTriggerExit(Collider col)
//    {
        
//        interactionMesh.enabled = false;

//    }
//}
