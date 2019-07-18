﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class PlaneDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<AnchorInputListenerBehaviour>().gameObject.SetActive(false);
            this.gameObject.GetComponent<PlaneFinderBehaviour>().gameObject.SetActive(false);
        }
    }
}