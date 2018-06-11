using UnityEngine;
using System.Collections;

public class CameraFirstPerson : MonoBehaviour {

	private GameObject player;
	private Vector3 offsetPos;
	
	void OnEnable()
	{
		player = GameObject.FindWithTag("Player"); // Find the GameObject named Player
		offsetPos = new Vector3(0, 1f, 0f); // Set an offset position for the camera
		transform.rotation = player.transform.rotation; // Set the camera's rotation
		gameObject.transform.parent = player.transform; // Sets the player as the cameras Parent
	}
    void Update()
    {
        getkeydownE();
        Debug.DrawRay(this.transform.position, this.transform.forward * 3f, Color.green);
    }

	
	void LateUpdate()
	{
		transform.position = player.transform.position + offsetPos + player.transform.forward * 0.5f; // Follow the player plus the offset position plus half the players transform forward
	}
    private void getkeydownE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 3f))
            {
                if (hit.collider.tag == "OBJ")
                {
                    Debug.Log("OBJ HIT!");
                }
            }
        }
    }
}
