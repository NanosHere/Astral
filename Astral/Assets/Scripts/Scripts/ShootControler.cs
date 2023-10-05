using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour
{
    public GameObject look;
    public Camera cam;

    public GameObject lampPrefab;
    public int lampsOut;
    public bool reset = true;
    public bool resetAim = true;

    public bool aimMode = false;



    public Transform debugtransform;
    
    [SerializeField]
    private Transform fireTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (Input.GetKey(KeyCode.Mouse1) && aimMode == false && resetAim == true)
        {

            aimMode = true;
            resetAim = false;
            StartCoroutine(startAim());

        }
        else if(Input.GetKey(KeyCode.Mouse1) && aimMode == true && resetAim == true)
        {
            aimMode = false;
            resetAim = false;
            StartCoroutine(startAim());

        }

        if(aimMode== true)
        {
            float targetAngle = cam.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            Quaternion rotationaim = Quaternion.Euler(targetAngle, 0, targetAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 6 * Time.deltaTime);

            fireTransform.rotation = Quaternion.Lerp(transform.rotation, rotation, 6 * Time.deltaTime);

            if (Input.GetKey(KeyCode.Mouse0) && lampsOut < 3 && reset == true )
            {
                
                reset = false;
                StartCoroutine(fireLamp());
                StartCoroutine(reseting());


                lampsOut++;


            }
        }

    }


    IEnumerator fireLamp()
    {
        GameObject Projectile = Instantiate(lampPrefab);
        Projectile.transform.forward = look.transform.forward;
        Projectile.transform.position = fireTransform.position + fireTransform.forward;

        
        
        Projectile.GetComponent<LampProjectile>().launch();

        
        

        yield return new WaitForSeconds(1f);
        




    }
    IEnumerator reseting()
    {
        yield return new WaitForSeconds(1f);
        reset = true;

    }
    IEnumerator startAim()
    {
        yield return new WaitForSeconds(.5f);
        resetAim = true;

    }


}
