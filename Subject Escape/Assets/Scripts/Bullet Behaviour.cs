using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    //Start void when triggered
    private void OnCollisionEnter(Collision collision){
        //kill enemy when hit
        Destroy(gameObject);

        if(collision.gameObject.tag == "Enemy"){
        Destroy(collision.gameObject);
        }
    }
}
