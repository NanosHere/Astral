using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effecthitbox : MonoBehaviour
{




    public void OnTriggerEnter(Collider other)
    {
       
            Debug.Log("Enter");
        //Physics.IgnoreLayerCollision(6, 1, true);
        if(other.gameObject.tag == "World1")
        {
            Debug.Log("World1");
        }
        else if (other.gameObject.tag == "World1")
        {
            Debug.Log("World2");
        }

            other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("trigger");
        Debug.Log(LayerMask.NameToLayer("Players"));

        //other.GetComponent<BoxCollider>();



    }

    public void OnTriggerExit(Collider other)
    {
       
            Debug.Log("exit");
            other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Players", "trigger");
        //other.GetComponent<BoxCollider>().enabled = true;
        //Physics.IgnoreLayerCollision(6, 1, false);
        //other.GetComponent<BoxCollider>().includeLayers = 11;



    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
