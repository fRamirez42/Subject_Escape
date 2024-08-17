using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour{

    //Start void when triggered
    private void OnCollisionEnter(Collision collision){
        //Destroy bullet when hitting something
        Destroy(gameObject);

        //Destroy player when player is hit
    }
}
