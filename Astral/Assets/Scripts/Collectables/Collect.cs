using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject collectVis;
    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.gameObject.layer);
        if (hit.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            collectVis.SetActive(true);
            this.gameObject.SetActive(false);
            Debug.Log("COLLECTED!!");
        }
    }
}
