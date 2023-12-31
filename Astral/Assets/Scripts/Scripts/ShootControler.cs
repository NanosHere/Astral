using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public GameObject aimCamera;
    public GameObject freeCam;
    public LayerMask contactlayers;
    public PlayerMovement moving;



    public Transform debugtransform;
    
    [SerializeField]
    private Transform fireTransform;

    [Header("Input")]
    public InputActionReference ZoomControl;
    public InputActionReference ShootControl;
    public InputActionReference ReturnFirstControl;
    public InputActionReference ReturnLastControl;

    // Start is called before the first frame update
    void Start()
    {
        ZoomControl.action.Enable();
        ShootControl.action.Enable();
        ReturnFirstControl.action.Enable();
        ReturnLastControl.action.Enable();
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        GameObject[] lamps = GameObject.FindGameObjectsWithTag("effector");
        lampsOut = lamps.Length;
    }
    // Update is called once per frame
    void Update()
    {
        

        if (ReturnLastControl.action.triggered)
        {
            StartCoroutine(returnLamp(true));
        }
        if (ReturnFirstControl.action.triggered)
        {
            StartCoroutine(returnLamp(false));
        }

        //start aim mode
        if (ZoomControl.action.triggered && aimMode == false )
        {


            aimMode = true;
            resetAim = false;
            StartCoroutine(startAim());
            aimCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 10;
            freeCam.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 9;
        }
        //stop aim mode
        else if(ZoomControl.action.triggered && aimMode == true )
        {
            aimMode = false;
            resetAim = false;
            StartCoroutine(startAim());
            aimCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 9;
            freeCam.GetComponent<Cinemachine.CinemachineFreeLook>().Priority = 10;


        }

        if (aimMode == true)
        {




            //rotate player charact to face the aim location.
            Vector3 worldPoint = Vector3.zero;
            float targetAngle = cam.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
           
           // transform.rotation 
                
            moving.playerChar.transform.rotation = Quaternion.Lerp(moving.playerChar.transform.rotation, rotation, 6 * Time.deltaTime);





            Vector2 sceenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = cam.ScreenPointToRay(sceenCenterPoint);

            // draw a ray to aim
            if (Physics.Raycast(ray, out RaycastHit raycasthit, 99f,contactlayers))
            {
                debugtransform.position = raycasthit.point;
                worldPoint = raycasthit.point;
            }
            else
            {
                
                // if does not hit anything play a shoot location
                worldPoint = cam.gameObject.transform.position + cam.gameObject.transform.forward * 50;
                //worldPoint.x = ; 
                debugtransform.position = worldPoint;

            }

            //get aim direction based on worldposition;
            Vector3 aimdir = worldPoint;
             aimdir.y = transform.rotation.y; 
             aimdir = (worldPoint - launchpoint.transform.position).normalized;
            




            Quaternion aimrotation = Quaternion.LookRotation(aimdir, Vector3.up);



            
            
            // change launch direction
            launchpoint.transform.rotation = Quaternion.Lerp(launchpoint.transform.rotation, aimrotation, 10 * Time.deltaTime);

            // launchpoint.gameObject.transform.rotation = Quaternion.Lerp(launchpoint.gameObject.transform.rotation, rotation, 6 * Time.deltaTime);


            // launch the lamp.
            if (ShootControl.action.triggered && lampsOut < 3 && reset == true )
            {
                
                reset = false;
                StartCoroutine(fireLamp());
                StartCoroutine(reseting());


                lampsOut++;


            }
        }




    }


    public void StartGameplay()
    {
        freeCam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Transitions.m_InheritPosition = true;
    }

    // create a lamp and launch it
    IEnumerator fireLamp()
    {
        GameObject Projectile = Instantiate(lampPrefab);
        Projectile.transform.forward = launchpoint.gameObject.transform.forward;
        Projectile.transform.position = launchpoint.gameObject.transform.position + launchpoint.gameObject.transform.forward;
        Projectile.GetComponent<LampProjectile>().launch();

        
        

        yield return new WaitForSeconds(.5f);
        




    }
    IEnumerator reseting()
    {
        yield return new WaitForSeconds(.5f);
        reset = true;

    }
    IEnumerator startAim()
    {
        yield return new WaitForSeconds(.5f);
        resetAim = true;

    }

    // when q is pressed destroy object and let player shoot one
    IEnumerator returnLamp(bool Return)
    {
      
        if(Return == true) { 
            yield return new WaitForSeconds(.001f);

            GameObject[] lamps = GameObject.FindGameObjectsWithTag("effector");
            //Debug.Log(lamps.Length);
            switch (lamps.Length)
            {
                case 0:

                    break;
                case 1:
                    lamps[0].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 0;
                    break;
                case 2:
                    lamps[0].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 1;
                    break;
                case 3:
                    lamps[0].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 2;
                    break;


            }
        }
        else
        {
            yield return new WaitForSeconds(.001f);

            GameObject[] lamps = GameObject.FindGameObjectsWithTag("effector");
            //Debug.Log(lamps.Length);
            switch (lamps.Length)
            {
                case 0:

                    break;
                case 1:
                    lamps[0].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 0;
                    break;
                case 2:
                    lamps[1].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 1;
                    break;
                case 3:
                    lamps[2].GetComponent<LampProjectile>().destroyThis();
                    //lampsOut = 2;
                    break;


            }
        }
    }


}
