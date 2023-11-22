using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveControllerForEnd : MonoBehaviour
{
    public float value1 = 0;
   
    public GameObject Aoe;
    
   

    public Material disolvematerial;


    
    //public Vector3 closestPoint;


    private void Start()
    {
        disolvematerial = this.gameObject.GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    private void Update()
    {
        //var component = GetComponent<Collider>();

        //closestPoint = component.ClosestPoint();
        //Debug.Log(closestPoint);

        

        if(this.gameObject.GetComponent<InteractableObJect>().interacted > 0)
        {
            value1 = 500;
            disolvematerial.SetFloat("_SimpleDisolvesize4", value1);
            disolvematerial.SetVector("_ObjectPosition4", Aoe.transform.position);
        }
        
       




    }
}
