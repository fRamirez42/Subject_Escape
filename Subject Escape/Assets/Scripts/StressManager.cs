using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StressManager : MonoBehaviour
{
    //Variables
    public int stressLevelPlayer = 0;
    private int stressAddShooting = 5;
    private int stressAddHide = 1;
    private int stressAddRead = 2;
    public TextMeshProUGUI counter;

    void Start() {
        //Start HUD text on 0
        counter.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Turns the Int into a String
        counter.text = stressLevelPlayer.ToString();

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
