using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
   public GameObject Player;

   public Transform FirePoint;

   public Transform Camera;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        RaycastHit hit;

        Vector3 Aim = Camera.transform.rotation.eulerAngles;

        if(Physics.Raycast(FirePoint.position , FirePoint.forward , out hit , 100))
        {
            Debug.DrawRay(FirePoint.position, FirePoint.forward * hit.distance, Color.red);
        }
    }
}
