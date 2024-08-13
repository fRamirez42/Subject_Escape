using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerWeapon : MonoBehaviour
{

    public GameObject Player;
    //prefab that will be used
    public GameObject bulletPrefab;

    //Spawn in the bullet
    public Transform bulletSpawn;

    //Set bullet speed
    public float bulletSpeed = 1000;

    //set the time for which the bullet will exist
    public float lifeTime = 3;

    //create can shoot boolean
    public bool canShoot = true;

    //set time between shots
    public float shotDelayInSeconds = 1;

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

        if (canShoot == true){
        //create an instance of the bullet
        GameObject bullet = Instantiate(bulletPrefab);

        //ignore collision between bulletand player
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), Player.GetComponent<Collider>());
        
        //set bullet position when spawned
        bullet.transform.position = bulletSpawn.position;

        //angle for bullet at spawn
        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        //assign speed to bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        //start timer to delete bullet after 3 seconds
        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));

        //prevent next shot
        canShoot = false;
        
        //call function to delay next shot
        StartCoroutine(ShootDelay());
        }
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay){
        //wait for delay time to pass
        yield return new WaitForSeconds(delay);

        //destroy the bullet object
        Destroy(bullet);
    }

    //Delay next shot
    private IEnumerator ShootDelay()
  {
    yield return new WaitForSeconds(shotDelayInSeconds);
    canShoot = true;
  }
}
