using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    


    public GameObject collectVis;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT!!");
    }
    /*
    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log("HIT!!");
        if (hit.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            collectVis.SetActive(true);
            this.gameObject.SetActive(false);
            Debug.Log("COLLECTED!!");
        }
    }
    */
}
