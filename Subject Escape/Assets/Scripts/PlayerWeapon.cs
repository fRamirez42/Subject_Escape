using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //prefab that will be used
    public GameObject bulletPrefab;

    //Spawn in the bullet
    public Transform bulletSpawn;

    //Set bullet speed
    public float bulletSpeed = 1000;

    //set the time for which the bullet will exist
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if left click is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Fire();
        }
    }

    private void Fire(){
        //create an instance of the bullet
        GameObject bullet = Instantiate(bulletPrefab);

        //Ignore collision between bullet and gun
        

        //set bullet position when spawned
        bullet.transform.position = bulletSpawn.position;

        //angle for bullet at spawn
        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        //assign speed to bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay){
        //wait for delay time to pass
        yield return new WaitForSeconds(delay);

        //destroy the bullet object
        Destroy(bullet);
    }
}
