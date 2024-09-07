using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentManager : MonoBehaviour
{
    public StressManager documentstress;
    public MeshRenderer PRender;
    private bool isPlayerInCollider = false;
    private bool isDocumentVisible = false; // Track if document is visible
    public TextMeshProUGUI doc1;
    public MeshCollider PRcollider;

    // Start is called before the first frame update
    void Start()
    {
        PRender.enabled = true;
        doc1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in the collider and if the 'E' key is pressed
        if (isPlayerInCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the document's visibility
            isDocumentVisible = !isDocumentVisible;

            // If the document is now visible, enable the document, disable MeshRenderer and MeshCollider
            if (isDocumentVisible)
            {
                doc1.gameObject.SetActive(true);
                documentstress.flashbackReading();
                PRender.enabled = false;
                PRcollider.enabled = false;
                Debug.Log("Document is now visible, MeshRenderer disabled");
            }
            // If the document is now hidden, disable the document
            else
            {
                doc1.gameObject.SetActive(false);
                Debug.Log("Document is now hidden");
            }
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
