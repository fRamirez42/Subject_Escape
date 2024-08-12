using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressManager : MonoBehaviour
{
    public float stressLevelPlayer = 0f;
    private float stressAddShooting = 5f;
    private float stressAddHide = 1f;
    private float stressAddRead = 2f;

    // Update is called once per frame
    void Update()
    {
        if (stressLevelPlayer > 100) { 
            //Allow monsters to roam ts
        }    
    }

    public void isShotAt() {
        stressLevelPlayer += stressAddShooting;
    }

    public void playerShoots() {
        stressLevelPlayer += stressAddShooting;
    }

    public void stressHiden() {
        stressLevelPlayer += stressAddHide;
    }

    public void flashbackReading() {
        stressLevelPlayer += stressAddRead;
    }
}
