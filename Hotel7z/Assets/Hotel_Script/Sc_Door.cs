using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Door : MonoBehaviour {

    public bool isOpen = false; // ture  = 열려 있음 false = 닫혀있음 
    public bool isLock = false; // ture = 잠겨있음 false = 열려 있음 

    public bool nowOpning = false; // 열리고 있으면 트루  
    public bool nowclosing = false;// 닫히고 있으면 트루 

    public Animator animator;
    string strAnimator = "open";

    public GameObject MainDoor;
    void Start()
    {
        animator = MainDoor.GetComponent<Animator>();
        
    }
    void Update () {
		
	}
    public void DOORTEST()
    {

        if (animator.GetBool(strAnimator) == false) //닫혀있다면 연다 
        {
            Debug.Log("DOOR TEST" + animator.GetBool(strAnimator));
            animator.SetBool(strAnimator, true);
        }
        if (animator.GetBool(strAnimator) == true) // 열려 있다면 닫힌다.
        {
            animator.SetBool(strAnimator, false);
        }

        //if (animator.GetBool(strAnimator) == false ) //닫혀있다면 연다 
        //{
        //    Debug.Log("DOOR TEST" + animator.GetBool(strAnimator));
        //    if (!nowOpning) // 열리는 중이면 가만히 있어라 
        //    {
        //        animator.SetBool(strAnimator, true);
        //    }
        //    else
        //    {
        //        Debug.Log("열리고있어 기다려!");
        //    }

        //}

        //if(animator.GetBool(strAnimator) == true ) // 열려 있다면 닫힌다.
        //{
        //    if (!nowclosing) // 열리는 중이면 가만히 있어라 
        //    {
        //        animator.SetBool(strAnimator, false);
        //    }
        //    else
        //    {
        //        Debug.Log("닫히고 있어 기다려!");
        //    }
        //}

    }
    public void doorOpen()
    {

        Debug.Log("DEEEEEEEEEEEEP doorOpen 몇번 들어왔어?");
        animator.SetBool(strAnimator, true);
        isOpen = true;


    }
    public void doorClose()
    {
        Debug.Log("DEEEEEEEEEEEEP doorClose 몇번 들어왔어?");
        animator.SetBool(strAnimator, false);
        isOpen = false;
    }
    public bool doorLock()
    {
        return true;
    }
    //public void startOpening()
    //{
    //    Debug.Log("startOpen()!");
    //    nowOpning = true;
    //}
    //public void endOpening()
    //{
    //    Debug.Log("endOpen()!");
    //    nowOpning = false;
    //}
    //public void startclosing()
    //{
    //    Debug.Log("startclosing()!");
    //    nowOpning = true;
    //}
    //public void endclosing()
    //{
    //    Debug.Log("endclosing()!");
    //    nowOpning = false;
    //}

}
