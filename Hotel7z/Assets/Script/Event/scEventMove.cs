using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//박세찬 
// 이 스크립트의 목적
//      1.오브젝트를 빈게임오브젝트까지 움직이게 하는 것이 목적이다. 
// 이 스크립트의 특징 
//      1.오브젝트의 이동 이벤트가 많을거같아 이 스크립트를 재활용 할수있게 코딩해야한다.
//      2. 오브젝트를 특정 벡터 지역이 아닌 빈게임오브젝트로 향하게 끔 해서 쉽게 이벤트 제작을 할수있게 만든다. 
//          -> lerp문이 적절해 보임 
public class scEventMove : MonoBehaviour, iEvent
{

    public scEventRunner Runner;
    public Transform startMarker; // 
    public Transform endMarker;
    public float speed = 1.0F;
    public bool DoYouWantSpin = false;
    public float rotateSpeed = 1f;
    [Range(0f, 90f)]
    public float x;
    [Range(0f, 90f)]
    public float y;
    [Range(0f, 90f)]
    public float z;
    private float startTime;
    private float journeyLength;
    Quaternion rotation;

    // Use this for initialization
    void Start()
    {

       // Runner.SetEvent(this);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position); // 두사이간의 거리 
        rotation = Quaternion.identity;
        //rotation.eulerAngles = new Vector3(x, y, z);

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Run()
    {
        StartCoroutine(move());
    }
    IEnumerator move() //  
    {
        //이거실행
        while (endMarker.position != startMarker.position)
        {
            float distCovered = (Time.time - startTime) * speed; // 속도관련 

            float fracJourney = distCovered / journeyLength; // 시간 구하는 값 T 분수여야 0~1이니까 분수값으로 

            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime); // 보간법을 이용한 회전
            if (DoYouWantSpin)
            {
                transform.Rotate(new Vector3(x, y, z)); // 영 맘에 들지않음 
            }
            yield return null;

        }






        yield return null;
    }

    IEnumerator Corutine()
    {
        //이거실행
        while (endMarker.position != startMarker.position)
        {
            //코드조각
            yield return null;
        }//실행
    }

    public void GetiEvent(object obj) { (obj as scEventRunner).SetUpEvt(this); }

}
