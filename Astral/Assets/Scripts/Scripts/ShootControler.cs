using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour
{
    public GameObject look;
    public Camera cam;

    public GameObject lampPrefab;
    public GameObject launchpoint;

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





            Vector3 worldPoint = Vector3.zero;
            float targetAngle = cam.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
           
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);





            Vector2 sceenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = cam.ScreenPointToRay(sceenCenterPoint);

            
            if (Physics.Raycast(ray, out RaycastHit raycasthit, 99f))
            {
                debugtransform.position = raycasthit.point;
                worldPoint = raycasthit.point;
            }
            else
            {
                Debug.Log("donthit");

                worldPoint = cam.gameObject.transform.position + cam.gameObject.transform.forward * 50;
                //worldPoint.x = ; 
                debugtransform.position = worldPoint;

            }
            Vector3 aimdir = worldPoint;
             aimdir.y = transform.rotation.y; 
             aimdir = (worldPoint - launchpoint.transform.position).normalized;
            




            Quaternion aimrotation = Quaternion.LookRotation(aimdir, Vector3.up);



            
            //Debug.Log(aimrotation);

            launchpoint.transform.rotation = Quaternion.Lerp(launchpoint.transform.rotation, aimrotation, 10 * Time.deltaTime);

            // launchpoint.gameObject.transform.rotation = Quaternion.Lerp(launchpoint.gameObject.transform.rotation, rotation, 6 * Time.deltaTime);



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
        Projectile.transform.forward = launchpoint.gameObject.transform.forward;
        Projectile.transform.position = launchpoint.gameObject.transform.position + launchpoint.gameObject.transform.forward;
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
