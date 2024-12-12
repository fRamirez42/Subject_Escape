using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAction : MonoBehaviour
{
    public GameObject explosion;  // Reference to the explosion prefab
    private bool isPlayerInCollider = false;
    public Vector3 explosionPosition = new Vector3(-1800, 121, -2010); // Desired explosion position
    private int counter = 0;
    public GameObject rocks;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in the collider
        if (isPlayerInCollider && counter == 0)
        {
            // Instantiate the explosion at the specified position
            Instantiate(explosion, explosionPosition, Quaternion.identity);

            // Disable MeshRenderer and MeshCollider for all child objects under 'rocks'
            MeshRenderer[] meshRenderers = rocks.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.enabled = false;  // Turn off mesh rendering for child objects
            }

            MeshCollider[] meshColliders = rocks.GetComponentsInChildren<MeshCollider>();
            foreach (MeshCollider meshCollider in meshColliders)
            {
                meshCollider.enabled = false;  // Turn off mesh colliders for child objects
            }

            // Reset the flag so the explosion only happens once
            isPlayerInCollider = false;

            counter++;


        }
    }

    // Called when the player enters the collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ExplosionSetOff")
        {
            isPlayerInCollider = true;
            Debug.Log("Player entered collider");
        }
    }


}
