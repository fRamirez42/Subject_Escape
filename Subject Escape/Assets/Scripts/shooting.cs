using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //conecta el codigo de stressmanager con este para podrer llamar a sus funciones
    public StressManager shootingStress;
    public GameObject Player;

    public Transform FirePoint;

    public Transform Camera;

    public bool canShoot = true;
    public float shotDelayInSeconds = 5;



    // Update is called once per frame
    void Update()
    {
        //chequea si se apreta el left click y si la variable canshoot (la que no permite disparar rapido) es true
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            //llama al metodo de disparo
            Shooting();
            //cambia la variable canshoot para que no se pueda disparar de nuevo
            canShoot = false;
            //empieza el conteo de tiempo para permitir que se dispare de nuevo
            StartCoroutine(ShootDelay());
            //llama al metodo de agregar stress al player cuando dispara
            shootingStress.playerShoots();
        }
    }

    public void Shooting()
    {
        //crea el hit del raycast
        RaycastHit hit;

        //crea el vector que apunta el raycast
        Vector3 Aim = Camera.transform.rotation.eulerAngles;


        //se fija si el raycast choca contra algo en 100 units or less (podemo cambiar eso si queremos mas lejos)
        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 100))
        {
            //inicializa el "target" aka the object hit by our ray"
            GameObject target = hit.transform.gameObject;
            //checks if target hit is "enemy"
            if (target.tag.Contains("Enemy"))
            {
                //Destroy enemy
                Destroy(target);
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelayInSeconds);
        canShoot = true;
    }
}
