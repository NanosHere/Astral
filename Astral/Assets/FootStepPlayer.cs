using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipSourceW1;
    [SerializeField] List<AudioClip> clipSourceW2;

    int currentClip = 0;
    public AudioSource AudioSource;
    [SerializeField] GameObject groundpoint;
    public bool step =  false;
    public bool insideRange = false;

    public LayerMask W1mask;
    public LayerMask W2mask;

    public void PlayFootstep()
    {
        RaycastHit hit;
        if(step== false) {

            if(insideRange == true)
            {
                Physics.Raycast(groundpoint.transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f, W2mask);
                currentClip = hit.transform.GetComponent<InteractableObJect>().soundNumber;
                AudioSource.PlayOneShot(clipSourceW2[currentClip]);
            }
            else
            {
                Physics.Raycast(groundpoint.transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f, W1mask);
                currentClip = hit.transform.GetComponent<InteractableObJect>().soundNumber;
                AudioSource.PlayOneShot(clipSourceW1[currentClip]);
            }

           // Physics.Raycast(groundpoint.transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            
            
            //Debug.Log("step");
            step = true;
        }
    }
    
    public void resetStep()
    {
        step = false;
    }

}
