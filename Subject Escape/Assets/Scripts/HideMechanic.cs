using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{
    public StressManager sm;
    public GameObject cam1;
    public GameObject cam2;
    public MeshRenderer PRender;
    public GameObject bedCollider;  // The collider associated with the bed

    private bool isPlayerInCollider = false;
    private bool isHiding = false;

    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void Update()
    {

        // Check if the 'E' key is pressed and the player is in the collider
        if (isPlayerInCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle hiding state
            isHiding = !isHiding;

            if (isHiding)
            {
                // Disable the MeshRenderer to hide the player
                PRender.enabled = false;

                // Switch camera views
                cam1.SetActive(false);
                cam2.SetActive(true);

                // Set the active camera to the main display
                cam2.GetComponent<Camera>().targetDisplay = 0;  // Assign to Display 1 (0 index)
                Debug.Log("Player is now hiding under the bed");
            }
            else
            {
                // Re-enable the MeshRenderer to show the player
                PRender.enabled = true;

                // Switch back the camera views
                cam1.SetActive(true);
                cam2.SetActive(false);

                // Set the active camera to the main display
                cam1.GetComponent<Camera>().targetDisplay = 0;  // Assign to Display 1 (0 index)
                Debug.Log("Player is no longer hiding under the bed");
            }
        }
    }


    // Called when the player enters the collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInCollider = true;
            Debug.Log("Player entered bed collider");
        }
    }

    // Called when the player exits the collider
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayerInCollider = false;

            // Ensure the player is not hiding when they leave the collider
            if (isHiding)
            {
                // Re-enable the MeshRenderer and switch camera views back
                PRender.enabled = true;
                cam1.SetActive(true);
                cam2.SetActive(false);

                isHiding = false;
                Debug.Log("Player exited collider and is no longer hiding");
            }

            Debug.Log("Player exited bed collider");
        }
    }

}
