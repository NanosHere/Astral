using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effecthitbox : MonoBehaviour
{




    public void OnTriggerEnter(Collider other)
    {
        

        //Physics.IgnoreLayerCollision(6, 1, true);
        if (other.gameObject.layer == LayerMask.NameToLayer("World1"))
        {
           
            if(other.gameObject.GetComponent<InteractableObJect>() != null) { 
            other.gameObject.GetComponent<InteractableObJect>().isInteractable = false;
            other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Trigger");
            }

        }
         if (other.gameObject.layer == LayerMask.NameToLayer("World2"))
        {
            if (other.gameObject.GetComponent<InteractableObJect>() != null)
            {
                
                other.gameObject.GetComponent<InteractableObJect>().isInteractable = true;
                other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Players", "Trigger", "Interactablelaunch");
                Debug.Log("wowza");
            }
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("PushableW1"))
        {

            other.gameObject.GetComponent<Rigidbody>().mass = 1;
            
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("World1Passthrough"))
         {

                
                    
            other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Trigger");
                

         }

        

        //other.GetComponent<BoxCollider>();



    }

    public void OnTriggerExit(Collider other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("World1"))
        {
            if (other.gameObject.GetComponent<InteractableObJect>() != null)
            {
                other.gameObject.GetComponent<InteractableObJect>().isInteractable = true;

                other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Players", "Trigger", "Interactablelaunch");
            }
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("World2"))
        {
            if (other.gameObject.GetComponent<InteractableObJect>() != null)
            {
                other.gameObject.GetComponent<InteractableObJect>().isInteractable = false;
                Debug.Log("World2");
                other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Trigger");
            }
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("PushableW1"))
        {

            other.gameObject.GetComponent<Rigidbody>().mass = 1000;
            Debug.Log("exit");
        }
         if (other.gameObject.layer == LayerMask.NameToLayer("World1Passthrough"))
        {



            other.GetComponent<BoxCollider>().includeLayers = LayerMask.GetMask("Players", "Trigger");


        }


        //other.GetComponent<BoxCollider>().enabled = true;
        //Physics.IgnoreLayerCollision(6, 1, false);
        //other.GetComponent<BoxCollider>().includeLayers = 11;



    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
