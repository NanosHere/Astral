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
        rigidbody.AddForce(transform.forward * (100 * Random.Range(1.3f, 1.7f)), ForceMode.Impulse);
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();

        source.GenerateImpulse(Camera.main.transform.forward);
    }


    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name != "Player")
        //{
        //    rigidbody.isKinematic = true;
           
        //}
    }

    public void destroyThis()
    {
        Destroy(this.gameObject, 1);
    }
    
}
