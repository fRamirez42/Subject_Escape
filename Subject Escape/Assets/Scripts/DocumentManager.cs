using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    public StressManager documentstress;
    public MeshRenderer PRender;
    private bool isPlayerInCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        PRender.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'E' key is pressed and the player is in the collider
        if (isPlayerInCollider && Input.GetKeyDown(KeyCode.E))
        {
            documentstress.flashbackReading();

            // Disable the MeshRenderer
            PRender.enabled = false;
            Debug.Log("E key pressed while in collider, MeshRenderer disabled");
            
        }
    }

    // Called when the player enters the collider
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
