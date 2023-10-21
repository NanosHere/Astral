using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObJect : MonoBehaviour
{
    public bool isInteractable;



    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "World2")
        {
            isInteractable = false;
        }
        if (this.gameObject.tag == "World1")
        {
            isInteractable = true;
        }
        if (this.gameObject.tag == "impassible")
        {
            isInteractable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
