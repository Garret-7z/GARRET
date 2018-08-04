using UnityEngine;
using System.Collections;

public class PlayerInfo
{

}


public class CameraFirstPerson : MonoBehaviour {

	private GameObject player;
	private Vector3 offsetPos;

    public float Reach = 4.0F;

    public GameObject TextPrefab;
    [HideInInspector] public bool TextActive;
    [HideInInspector] public GameObject TextPrefabInstance;
    public GameObject CrosshairPrefab;
    [HideInInspector] public GameObject CrosshairPrefabInstance;
    [HideInInspector] public bool InReach;

    public GameObject match;
    public GameObject ScgameUi;
    public static int mentality;
    public static int medicinePower = 30;
    public static int Fear = 20;
    public static int medicine = 0;
    Sc_GameUi gameUI;

    void OnEnable()
	{
		player = GameObject.FindWithTag("Player"); // Find the GameObject named Player
		offsetPos = new Vector3(0, 1f, -0.5f); // Set an offset position for the camera
		transform.rotation = player.transform.rotation; // Set the camera's rotation
		gameObject.transform.parent = player.transform; // Sets the player as the cameras Parent
	}
    void Update()
    {
        mentality = Mathf.Clamp(mentality, 0, 100);
        //Debug.Log("Update : " + mentality);
    }
    private void Start()
    {
        StartCoroutine("corutineUpdate");
        gameUI = ScgameUi.GetComponent<Sc_GameUi>();
        //CrosshairPrefabInstance = Instantiate(CrosshairPrefab); @@
        //CrosshairPrefabInstance.transform.SetParent(transform, true);@@
    }
    private void FixedUpdate()
    {
        //keyupE();
        Debug.DrawRay(this.transform.position, this.transform.forward * 3f, Color.green);
    }


    void LateUpdate()
	{
		transform.position = player.transform.position + offsetPos + player.transform.forward * 0.5f; // Follow the player plus the offset position plus half the players transform forward
	}

    IEnumerator corutineUpdate()//RaycastHit hit
    {
        Debug.Log("corutineUpdate 들어왔어?");
        while (true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 3f))
                {
                    if (hit.collider.tag == "DOOR") //
                    {

                        //TextPrefabInstance = Instantiate(TextPrefab); @@ 


                        if (hit.transform.GetComponent<Sc_Door>().animator.GetBool("open") == false) // false 닫
                        {
                            hit.transform.GetComponent<Sc_Door>().doorOpen();
                        }
                        else if(hit.transform.GetComponent<Sc_Door>().animator.GetBool("open") == true)
                        {
                            hit.transform.GetComponent<Sc_Door>().doorClose();
                        }
                        
                    }

                    if(hit.collider.tag == "MEDICINE")
                    {

                        
                        gameUI.Uimedicine(++medicine);
                        Debug.Log("medicine 먹었어! 현재 수치 : " + medicine);
                        
                        Destroy(hit.collider.gameObject);

                    }
                }
                yield return new WaitForSeconds(0.8f);
            }      
            yield return null;
        }

    }
    
    


    /*
     * 
     * 
     * 
     * private void Ray() 
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit ,3f))
        {
            if(hit.collider.tag =="DOOR") // 
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if(!hit.transform.GetComponent<Sc_Door>().isOpen) // 닫혀있는거니까 "!" 
                    {
                        Debug.Log("open 몇번 들어왔어?");
                        StartCoroutine("plzwaitopen()");

                    }
                    if(hit.transform.GetComponent<Sc_Door>().isOpen) // ture는 열려있어
                    {
                        Debug.Log("close 몇번 들어왔어?");
                        StartCoroutine("plzwaitclose()");
                    }


                }
            }
        }


        // 병신같은 ray-------------------
        //RaycastHit hit;

        //if (Input.GetKeyDown(KeyCode.E))
        //{


        //    if (Physics.Raycast(this.transform.position, this.transform.forward, out hit,100f))
        //    {
        //        if (hit.collider.tag == "DOOR")
        //        {
        //            Debug.Log("DOOR HIT!");
        //            hit.collider.SendMessage("DOORTEST()");

        //        }
        //    }
        //}
    }
     */
}
