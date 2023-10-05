using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public GameObject Aoe;
    public GameObject Aoe2;
    public GameObject Aoe3;

    public Material disolvematerial;
    //public Vector3 closestPoint;

    // Update is called once per frame
    private void Update()
    {
        //var component = GetComponent<Collider>();

        //closestPoint = component.ClosestPoint();
        //Debug.Log(closestPoint);

        disolvematerial.SetVector("_ObjectPosition", Aoe.transform.position);
        disolvematerial.SetVector("_ObjectPosition2", Aoe2.transform.position);
        disolvematerial.SetVector("_ObjectPosition3", Aoe3.transform.position);



    }
}
