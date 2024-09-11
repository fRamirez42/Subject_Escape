using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject player;

    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Im a bar, i do bar stuff, like barring you from editing this code, since it works perfectly fine. BARRED!
        int vida = health.Health;
        

    }
}
