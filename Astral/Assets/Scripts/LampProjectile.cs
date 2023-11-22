using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampProjectile : MonoBehaviour
{
    public float force;
    public float size;
    public Rigidbody rigidbody;
    Cinemachine.CinemachineImpulseSource source;
    public GameObject aoe;
    float lerpDuration = .5f;



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
            StartCoroutine(lampField(true));
           
        }
    }

    public void destroyThis()
    {
        //aoe.transform.localScale = new Vector3(.1f, .1f, .1f);
        StartCoroutine(lampField(false));

        Destroy(this.gameObject, .7f);
    }



    IEnumerator lampField(bool grow)
    {
        if (grow == true)
        {
            //size = Mathf.Lerp(size, 10, 50 * Time.deltaTime);
           // aoe.transform.localScale = Vector3.Lerp(new Vector3(.1f, .1f, .1f), new Vector3(39f, 39f, 39f), 50 * Time.deltaTime);
            float timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                size = Mathf.Lerp(size, 10, timeElapsed / lerpDuration);

                aoe.transform.localScale = Vector3.Lerp(new Vector3(.1f, .1f, .1f), new Vector3(39f, 39f, 39f), timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            size = 10;
            aoe.transform.localScale = new Vector3(39f, 39f, 39f);



        }
        else
        {
            float timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                size = Mathf.Lerp(size, 0, timeElapsed / lerpDuration);

                aoe.transform.localScale = Vector3.Lerp(new Vector3(39f, 39f, 39f), new Vector3(.1f, .1f, .1f), timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            size = 0;
            this.gameObject.transform.position = new Vector3(999, 999, 999);
            aoe.transform.localScale = new Vector3(.1f, .1f, .1f);
            

        }


        yield return null;
    }


}
/*
  public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(aoe.transform.localScale);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "World1" )
        {w
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