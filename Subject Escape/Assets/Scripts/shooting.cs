using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject Player;

    public Transform FirePoint;

    public Transform Camera;

    public bool canShoot = true;
    public float shotDelayInSeconds = 5;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            Shooting();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
        RaycastHit hit;

        Vector3 Aim = Camera.transform.rotation.eulerAngles;

        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 100))
        {
            GameObject target = hit.transform.gameObject;
            if(target.tag.Contains("Enemy")){
                
            }
            Debug.DrawRay(FirePoint.position, FirePoint.forward * hit.distance, Color.red);
        }
    }

    public void Shooting()
    {
        RaycastHit hit;

        Vector3 Aim = Camera.transform.rotation.eulerAngles;

        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 100))
        {
            GameObject target = hit.transform.gameObject;
            if(target.tag.Contains("Enemy")){
                Destroy(target);
            }
            Debug.DrawRay(FirePoint.position, FirePoint.forward * hit.distance, Color.red);
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelayInSeconds);
        canShoot = true;
    }
}
