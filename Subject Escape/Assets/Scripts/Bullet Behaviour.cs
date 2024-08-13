using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    //Start void when triggered
    private void onTriggerEnter(Collider other){
        //kill enemy when hit
        Destroy(gameObject);
    }
}
