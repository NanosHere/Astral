using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float value1 = 0;
    public float value2 = 0;
    public float value3 = 0;
    public GameObject[] Aoe;
   

    public Material disolvematerial;
    //public Vector3 closestPoint;

    // Update is called once per frame
    private void Update()
    {
        //var component = GetComponent<Collider>();

        //closestPoint = component.ClosestPoint();
        //Debug.Log(closestPoint);

        Aoe =  GameObject.FindGameObjectsWithTag("effector");


        switch (Aoe.Length)
        {
            case 0:
                value1 = 0;
                value2 = 0;
                value3 = 0;
                break;

            case 1:
                value1 = 10;
                value2 = 0;
                value3 = 0;
                break;
            case 2:
                value1 = 10;
                value2 = 10;
                value3 = 0;
                break;
            case 3:
                value1 = 10;
                value2 = 10;
                value3 = 10;
                break;

        }

       

        disolvematerial.SetFloat("_SimpleDisolvesize", value1);
        disolvematerial.SetFloat("_SimpleDisolvesize2", value2);
        disolvematerial.SetFloat("_SimpleDisolvesize3", value3);
        disolvematerial.SetVector("_ObjectPosition", Aoe[0].transform.position);
        disolvematerial.SetVector("_ObjectPosition2", Aoe[1].transform.position);
        disolvematerial.SetVector("_ObjectPosition3", Aoe[2].transform.position);



    }
}
