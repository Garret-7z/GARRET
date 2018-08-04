using UnityEngine;
using System.Collections;

public class FirstPersonMove : MonoBehaviour {

    // Animation script
    //private CharacterAnimation anim;
    public static bool ISEEYOU= false;

    Rigidbody rigidbody_;
    Collider col_;
    // Rotation variables
    public float   rotY,
					rotX,
					sensitivity = 10.0f;
	
	// Speed variables
	public float   speed = 10f,
	 				speedHalved = 7.5f,
	 				speedOrigin = 10f;
   
	// Jump!
	private float distToGround;

    bool test; 
    bool isSafe = false; // 안전한 장소(장롱안에 있는가) 
    public float bloodyDoorMaterialChangeInt = 0f;

    public GameObject ScgameUi;
    public GameObject[] ChangeOBJs;
    //Material bloodyDoorPR; //
    //Material mirrorMaterial;
    Sc_GameUi gameUi;
    Sc_enemy enemy;
    
    

    void Start()
	{
		//anim = GetComponent<CharacterAnimation>(); // Get the animation script
        rigidbody_ = GetComponent<Rigidbody>();
        col_ = GetComponent<Collider>();
        gameUi = ScgameUi.GetComponent<Sc_GameUi>();
        StartCoroutine("use_medicine");
        enemy = GameObject.FindWithTag("ENEMY").GetComponent<Sc_enemy>();
        // UI 초기화



    }


    void Update()
    {
        mentalChecker();
        
        //Test();
    }
    // FixedUpdate is used for physics based movement
    void FixedUpdate ()
	{
		float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
		float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
        MouseLook(); // Call the player look function which controls the mouse
		PlayerMove(horizontal,vertical); // Call the move player function sending horizontal and vertical movements
		//Jump(); // Call the Jump function! Woot!
	}
	
	private void MouseLook()
	{
		rotX += Input.GetAxis("Mouse X")*sensitivity; // set a float to control Mouse X input
		rotY += Input.GetAxis("Mouse Y")*sensitivity; // set a float to control Mouse Y input
		rotY = Mathf.Clamp (rotY, -90f, 90); // Lock rotY to a 90 degree angle for looking up and down
		transform.localEulerAngles = new Vector3(0,rotX,0); // Rotate the player mode left and right
		Camera.main.transform.localEulerAngles = new Vector3(-rotY,0,0); // Rotate the camera up and down rather than the player model
	}
    //void Test()
    //   {
    //       if (Input.GetKeyDown(KeyCode.P))
    //       {
    //           testF += 0.2f;
    //           ///bloodyDoor.SetFloat("_BloodAmount", testF);
    //           bloodyDoorTEST.SetFloat("_BloodAmount", testF);
    //           //ChangeOBJs[0].GetComponent<Renderer>().material.SetFloat("_BloodAmount", testF);
    //
    //           Debug.Log("TEST ::  "+ bloodyDoor.GetFloat("_BloodAmount"));
    //       }
    //   }

    void materialChanger()
    {
        //Sc_Gamebalancer.mentality;
    }

	private void PlayerMove(float h, float v)
	{
		if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
		{
			if(h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
			{
				speed = speedHalved; // Modify the speed to adjust for moving on an angle
			}
			else // If only horizontal OR vertical are pressed individually then continue
			{
				speed = speedOrigin; // Keep speed to it's original value
            }
            rigidbody_.MovePosition(rigidbody_.position + (transform.right * h) * speed * Time.deltaTime); // Move player based on the horizontal input
            rigidbody_.MovePosition(rigidbody_.position + (transform.forward * v) * speed * Time.deltaTime); // Move player based on the vertical input
			//anim._animRun = true; // Enable the run animation
		}
		else 	// If horizontal or vertical are not pressed then continue
		{
			//anim._animRun = false; // Disable the run animation
		}
	}
	
	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space)) // If the Space bar is pressed down then continue
		{
			if(IsGrounded()) // If the player is grounded, this calls a boolean, then continue
			{
                rigidbody_.velocity += 5f * Vector3.up; // add velocity to the player on vector UP
			}
		}
	}

	private bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, col_.bounds.extents.y + 0.1f); // Do a ray cast to see if the players collider is 0.1 away from the surface of something
	}

    IEnumerator use_medicine()
    {
        Debug.Log("corutineUpdate 들어왔어?");
        while (true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                //Sc_Gamebalancer.medicine
                if (0 < Sc_Gamebalancer.medicine )
                {
                    StartCoroutine("mentality_Up");
                    Debug.Log("Q 누름!! 현재 남은 갯수: " + Sc_Gamebalancer.medicine);
                    gameUi.Uimedicine(--Sc_Gamebalancer.medicine);
                    
                    yield return new WaitForSeconds(0.8f);
                }
                else
                {
                    Debug.Log("F 누름!! 현재 남은 갯수: " + Sc_Gamebalancer.medicine);
                    yield return new WaitForSeconds(0.8f);
                }
            }
            yield return null;
        }

    }

    IEnumerator mentality_Up()
    {
        
        float medicinePowertemp=0;
        while (medicinePowertemp < Sc_Gamebalancer.medicinePower)
        {
            medicinePowertemp += Sc_Gamebalancer.medicinePower/25.0f;


            Sc_Gamebalancer.mentality += Sc_Gamebalancer.medicinePower / 25.0f;
                Sc_Gamebalancer.mentality = Mathf.Clamp(Sc_Gamebalancer.mentality, 0, 100);
                gameUi.Uimentality(Sc_Gamebalancer.mentality);
            Debug.Log("medicinePowertemp : "+medicinePowertemp + "Sc_Gamebalancer.mentality : " +Sc_Gamebalancer.mentality);
                yield return null;
        }

    }

    IEnumerator mentality_dotdown()//
    {
        while (true)
        {
            Sc_Gamebalancer.mentality -= ((float)Sc_Gamebalancer.Fear / 50.0f);
            gameUi.Uimentality(Sc_Gamebalancer.mentality);
            yield return null;
        }
    }
    public void mentality_down()
    {
        Sc_Gamebalancer.mentality -= Sc_Gamebalancer.Fear;
        gameUi.Uimentality(Sc_Gamebalancer.mentality);
        
    }

    void mentalChecker() // 단계별로 멘탈 깎일때 변화하는 것들 
    {
        float mental = (float)Sc_Gamebalancer.mentality;
        if (Sc_Gamebalancer.mentality <= 25)
        {
            
            float material_max =10;
            float material_min = 7;

            bloodyDoorMaterialChangeInt = ((float)(mental) / 25.0f) * (material_max - material_min);
            bloodyDoorMaterialChangeInt = material_max - bloodyDoorMaterialChangeInt;
            //Debug.Log("bloodyDoorMaterialChangeInt : " + bloodyDoorMaterialChangeInt);
            //Debug.Log("Sc_Gamebalancer.mentality : " + Sc_Gamebalancer.mentality);
            //Debug.Log("mental : " + mental);
            Sc_GameMng.instance.bloodyDoorPR.SetFloat("_BloodAmount", bloodyDoorMaterialChangeInt);
            float fTemp = 1.0f - (mental / 25.0f);
            if (fTemp > 1.2)
            {
                fTemp = 1f;
            }
            Sc_GameMng.instance.mirrorMaterial.SetColor("_ReflectionColor", new Color(1.0f- fTemp, 0, 0));
            //Debug.Log("25<Color : " + (1.0f - fTemp));

        }
        else if (Sc_Gamebalancer.mentality <= 50)
        {
            //Debug.Log("mentality  50미만");
         
            float material_max = 7;
            float material_min = 4.5f;
            bloodyDoorMaterialChangeInt = ((float)(mental - 25.0f) / 25.0f) * (material_max - material_min);
            bloodyDoorMaterialChangeInt = material_max - bloodyDoorMaterialChangeInt;
            //Debug.Log("bloodyDoorMaterialChangeInt : " + bloodyDoorMaterialChangeInt);
            //Debug.Log("Sc_Gamebalancer.mentality : " + Sc_Gamebalancer.mentality);
            //Debug.Log("mental : " + mental);
            Sc_GameMng.instance.bloodyDoorPR.SetFloat("_BloodAmount", bloodyDoorMaterialChangeInt);
            float fTemp = 1.0f - ((mental - 25.0f) / 25.0f);
            if(fTemp >1.2)
            {
                fTemp = 0.9f;
            }
            Sc_GameMng.instance.mirrorMaterial.SetColor("_ReflectionColor", new Color(1, 1.0f - fTemp, 1.0f -fTemp));
            //Debug.Log("50<Color : Mental " + mental);
            //Debug.Log("50<Color : Mental 2 " + (((mental - 25.0f) / 25.0f)));
            //Debug.Log("50<Color : " + fTemp);
        }
        else if (Sc_Gamebalancer.mentality <= 75)
        {
            //Debug.Log("mentality  75미만");
         
            float material_max = 4.5f;
            float material_min = 0.7f;
            bloodyDoorMaterialChangeInt = ((float)(mental - 50.0f) / 25.0f) * (material_max - material_min);
            bloodyDoorMaterialChangeInt = material_max - bloodyDoorMaterialChangeInt;
            //Debug.Log("bloodyDoorMaterialChangeInt : " + bloodyDoorMaterialChangeInt);
            //Debug.Log("Sc_Gamebalancer.mentality : " + Sc_Gamebalancer.mentality);
            //Debug.Log("mental : " + mental);
            Sc_GameMng.instance.bloodyDoorPR.SetFloat("_BloodAmount", bloodyDoorMaterialChangeInt);
            Sc_GameMng.instance.mirrorMaterial.SetColor("_Color", new Color(1.0f - (((mental - 50.0f) / 25.0f)), 0, 0));
            //Debug.Log("75 < Color Mental : " + ((mental - 50.0f) / 25.0f));
            //Debug.Log("75<Color : " + (1.0f - ((mental - 50.0f) / 25.0f)));
        }
        else if (Sc_Gamebalancer.mentality <= 100)
        {
            //Debug.Log("mentality  100미만");
            
            float material_max = 0.7f;
            float material_min = 0f;
            bloodyDoorMaterialChangeInt = ((float)(mental - 75.0f) / 25.0f) * (material_max - material_min);
            bloodyDoorMaterialChangeInt = material_max - bloodyDoorMaterialChangeInt;
            //Debug.Log("bloodyDoorMaterialChangeInt : " + bloodyDoorMaterialChangeInt);
            //Debug.Log("Sc_Gamebalancer.mentality : " + Sc_Gamebalancer.mentality);
            //Debug.Log("mental : " + mental);
            Sc_GameMng.instance.bloodyDoorPR.SetFloat("_BloodAmount", bloodyDoorMaterialChangeInt);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DMGROOM")
        {
            //Debug.Log("OnTriggerEnter  들어왔어요!!!");
            StartCoroutine("mentality_dotdown");
        }
        if (col.gameObject.tag == "SAFEZONE")
        {
            if(ISEEYOU == true)
            {
                //계속 추적
            }
            else if(ISEEYOU == false)
            {
                enemy.monsterState = Sc_enemy.MonsterState.idle;
                isSafe = true;
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "DMGROOM")
        {
            //Debug.Log("OnTriggerStay  들어왔어요!!!");
            //StartCoroutine("mentality_dotdown");
        }
        if (col.gameObject.tag == "SAFEZONE")
        {

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "DMGROOM")
        {
            StopCoroutine("mentality_dotdown");

        }
        if (col.gameObject.tag == "SAFEZONE")
        {
            isSafe = false;
            enemy.monsterState = Sc_enemy.MonsterState.trace;
        }
    }
  
}