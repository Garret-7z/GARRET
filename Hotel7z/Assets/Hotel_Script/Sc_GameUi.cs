using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sc_GameUi : MonoBehaviour
{

    public Text Text_medicine;
    public Image image;
    int maxmental;
    public float total;
    public float test;
    int max = 354;

    // Use this for initialization
    void Start()
    {
        maxmental = 100;
        Uimentality(Sc_Gamebalancer.mentality); // UI 초기화

        //StartCoroutine("corutineUpdate");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Uimedicine(int nowMedicine)
    {
        Text_medicine.text = nowMedicine.ToString();
    }

    public void Uimentality(float mental) // UI 멘탈 표시
    {

        total = (mental / maxmental) * max;
        //Debug.Log("@mental@" + mental);
        //Debug.Log("@total@" + total );
        
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(total, 22.4f);
    }
    //public IEnumerator corutineUpdate()//RaycastHit hit
    //{
    //    while (true)
    //    {
    //        Debug.Log("@@@@");
    //        k72 -= 1;
    //        i
    //        yield return new WaitForSeconds(0.5f);
    //    }

       
    //}
}
