using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Sc_enemy : MonoBehaviour {
                                                                    // 플레이어의 신경도에 따른 상태 변화 
    public enum MonsterState { idle , trace , attack , around, die , NOMAL, INSECURE , VERT_INSECURE, DESPERATE }

    public float traceDist = 10f;
    public float attackDist = 1.5f;
    public MonsterState monsterState = MonsterState.idle;

    

    Transform enemyTr;
    Transform playerTr;
    NavMeshAgent nvAgent;
    float timeTemp;


    // Use this for initialization
    bool isDie = false;
	void Start () {

        enemyTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        monsterState = MonsterState.trace;
        timeTemp = Time.time;

        StartCoroutine("EnemyAction");
        StartCoroutine("Raycast");
        StartCoroutine("checkEnemyState");
    }
	
	// Update is called once per frame 
	void Update () {
        //Debug.Log("Time.time " + Time.time);
        //Test();
	}


    IEnumerator checkEnemyState()//범위에 맞춰서 행동을 적어주자@@
    {
        while (!isDie)
        {
            
            yield return new WaitForSeconds(0.5f);
            //Debug.Log("추적 시간 " + (timeTemp));
            if (timeTemp >Sc_Gamebalancer.traceTime)
            {
                monsterState = MonsterState.around;
            }
            float dis = Vector3.Distance(playerTr.position, enemyTr.position);
            if(dis <= attackDist) // 짧은 범위대로 
            {

            }
           
        }
    }
    void Test()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("눌렀으여!!@@@@@@");
            //Sc_GameMng.instance.TimeChecker(true);
            Sc_GameMng.instance.timeStop = true;
        }
    }
    IEnumerator EnemyAction()
    {
        while(!isDie)
        {
            switch(monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true; // 추적 중지 
                    //timeTemp = 0f;
                    Sc_GameMng.instance.timeStop = true;
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    //timeTemp += Time.deltaTime; // 추격시간
                    Sc_GameMng.instance.timeStop = false;
                    break;
                case MonsterState.NOMAL:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    //timeTemp += Time.deltaTime; // 추격시간
                    Sc_GameMng.instance.timeStop = false;
                    break;
                case MonsterState.INSECURE:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    //timeTemp += Time.deltaTime; // 추격시간
                    Sc_GameMng.instance.timeStop = false;
                    break;
                case MonsterState.VERT_INSECURE:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    //timeTemp += Time.deltaTime; // 추격시간
                    Sc_GameMng.instance.timeStop = false;
                    break;
                case MonsterState.DESPERATE:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    //timeTemp += Time.deltaTime; // 추격시간
                    Sc_GameMng.instance.timeStop = false;
                    break;
            }
            yield return null;
        }

    }
    
    IEnumerator Raycast()//RaycastHit hit
    {
        
        while (true) 
        {
            Vector3 vecTemp = transform.position - playerTr.position;
            transform.LookAt(playerTr);
            Debug.DrawRay(this.transform.position, this.transform.forward * 20f, Color.green);
            
            
            RaycastHit hit;
            // ScreenPointToRay와 ViewportPointToRay 차이점?
            //ScreenPointToRay는 클릭할떄 많이 쓰인다
            // ViewportPointToRayFPS 같은 자신이 보고있는 화면 정 중앙에서 쏜다.
            if (Physics.Raycast(transform.position, this.transform.forward * 20f, out hit , 20f))
            {
                
                if (hit.collider.tag == "Player") //
                {
                    FirstPersonMove.ISEEYOU = true;// true
                }
                else
                {
                    FirstPersonMove.ISEEYOU = false;
                }
                //Debug.Log("FirstPersonMove.ISEEYOU   "+ FirstPersonMove.ISEEYOU);

            }
            yield return null;
        }

    }
    
}
