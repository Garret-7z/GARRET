using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerBalancer
{

}
class MonsterBalancer
{

}

public class Sc_Gamebalancer : MonoBehaviour {
    //player 
    public static float mentality = 100.0f; // 신경도
    public static float medicinePower = 30.0f; // 약 회복량
    public static float Fear = 20.0f; // 도트 데미지
    public static int medicine = 1; // 현재 가진 약 갯수
    //enemy
    public static float traceTime = 90.0f;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
