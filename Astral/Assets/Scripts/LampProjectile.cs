using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampProjectile : MonoBehaviour
{
    public float force;
    public Rigidbody rigidbody;
    Cinemachine.CinemachineImpulseSource source;
    public GameObject aoe;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = transform.position;
        aoe.transform.localScale = new Vector3(39, 39, 39);
        aoe.gameObject.SetActive(false);
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
            aoe.gameObject.SetActive(true);
           
        }
    }

    public void destroyThis()
    {
        aoe.transform.localScale = new Vector3(.1f, .1f, .1f);
        Destroy(this.gameObject, .5f);
    }
    
}
/*
  public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(aoe.transform.localScale);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "World1" )
        {
            Debug.Log("hitbody");
            
            rigidbody.isKinematic = true;

            aoe.gameObject.SetActive(true);

            StartCoroutine(lampField(true));
        }
    }

    public void destroyThis()
    {
        //aoe.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(.1f, .1f, .1f), Time.deltaTime * 20);
        StartCoroutine(lampField(false));
        Destroy(this.gameObject, .5f);
    }

    IEnumerator lampField(bool grow)
    {
        if(grow == true)
        {
            size = Mathf.Lerp(size, 10, 50 * Time.deltaTime );
            aoe.transform.localScale = Vector3.Lerp(new Vector3(.1f, .1f, .1f), new Vector3(39f, 39f, 39f), 50 * Time.deltaTime);
           
        }
        else
        {
            size = Mathf.Lerp(size, 0, 50 * Time.deltaTime );
            aoe.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(.1f, .1f, .1f), 50 * Time.deltaTime );
            
        }

        
        yield return null;
    }
*/