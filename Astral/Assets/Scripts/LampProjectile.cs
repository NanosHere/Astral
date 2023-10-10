using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampProjectile : MonoBehaviour
{
    public float force;
    public Rigidbody rigidbody;
    Cinemachine.CinemachineImpulseSource source;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = transform.position;
    }
   

    public void launch()
    {
        rigidbody.AddForce(transform.forward * (force), ForceMode.Impulse);
        //source = GetComponent<Cinemachine.CinemachineImpulseSource>();

        //source.GenerateImpulse(Camera.main.transform.forward);
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hitsomething");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "World1" )
        {
            Debug.Log("hitbody");
            rigidbody.isKinematic = true;
           
        }
    }

    public void destroyThis()
    {
        Destroy(this.gameObject, .5f);
    }
    
}
