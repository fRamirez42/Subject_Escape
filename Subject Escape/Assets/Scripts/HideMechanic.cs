using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{
    public StressManager documentstress;
    public Movement move;
    public MeshRenderer PRender;
    private bool isPlayerInCollider = false;
    private bool isPlayerHiding = false;

    public Camera cam1;
    public Camera cam2;

    // Start is called before the first frame update
    void Start()
    {
        PRender.enabled = true;

        cam1.enabled = true;
        cam2.enabled = false;

        isPlayerHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'E' key is pressed, the player is in the collider, and the player is not already hiding
        if (isPlayerInCollider && Input.GetKeyDown(KeyCode.E) && !isPlayerHiding)
        {
            documentstress.flashbackReading();

            cam1.enabled = false;
            cam2.enabled = true;

            // Disable the MeshRenderer
            PRender.enabled = false;
            Debug.Log("E key pressed while in collider, MeshRenderer disabled");

            isPlayerHiding = true;
        }
        // Optionally, you might want to allow the player to exit hiding by pressing 'E' again
        else if (isPlayerHiding && Input.GetKeyDown(KeyCode.E))
        {
            cam1.enabled = true;
            cam2.enabled = false;

            // Re-enable the MeshRenderer if needed
            PRender.enabled = true;
            Debug.Log("E key pressed again, exiting hiding");

            isPlayerHiding = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInCollider = true;
            Debug.Log("Player entered collider");
        }
    }

    // Called when the player exits the collider
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInCollider = false;
            Debug.Log("Player exited collider");
        }
    }
}
