using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    //Start void when triggered
    private void OnTriggerEnter(Collider other){
        //kill enemy when hit
        print("hit " + other.name + "!");
        Destroy(gameObject);
        Destroy(other);
    }
}
