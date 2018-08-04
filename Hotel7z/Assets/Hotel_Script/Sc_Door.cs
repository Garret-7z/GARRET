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
        //this.transform.GetComponent<Renderer>().material.SetFloat("_BloodAmount", 0.5f);
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


    }
    public void doorOpen()
    {
        
        if (isLock) // true 잠겨있다. false 열려있다.
        {
            Sc_Sound._Instance.Run(2, this.transform);

        }
        else
        {
            Sc_Sound._Instance.Run(0, this.transform);
            Debug.Log("DEEEEEEEEEEEEP doorOpen 몇번 들어왔어?");
            animator.SetBool(strAnimator, true);
            isOpen = true;
        }

    }
    public void doorClose()
    {
        Sc_Sound._Instance.Run(1, this.transform);
        Debug.Log("DEEEEEEEEEEEEP doorClose 몇번 들어왔어?");
        animator.SetBool(strAnimator, false);
        isOpen = false;
    }


}
