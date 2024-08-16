using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthScript : MonoBehaviour
{


    public GameObject player;

    public float playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision characterShot){
        if(characterShot.gameObject.name.Contains("Enemy bullet")){
           Damaged(40);
        }
        print("player hit!");
    }

    public void Damaged(int damageTaken)
        {
            playerHealth -= damageTaken;
        }
}
