using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    public StressManager documentstress;
    public MeshRenderer PRender;

    // Start is called before the first frame update
    void Start()
    {
        PRender.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (col.gameObject.tag == "Player") {
            PRender.enabled = false;
        }
    }
}
