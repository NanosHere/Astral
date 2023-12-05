using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 input;
    public float curSpeed = 0f;
    public float maxSpeed = 10f;
    public Transform orientation;
    public Transform playerChar;

    public float rotationSpeed;
    public ShootControler shootie;

    //jump stuff
    [Header("jump")]

    public float jumpSpeed =10;
    public bool isDoubleJump;
    public bool isGrounded;
    public bool triggerJump;
    public Transform groundpos;
    public LayerMask mask;
    public float sphereRadisus;
    public RaycastHit groundcheckHit;
    private Transform extraOrientation;
    public ParticleSystem particles;

    [Header("PhysicsMat")]
    public PhysicMaterial PMat;

    [Header("Animation")]
    public Animator anim;

    [Header("Input")]
    public InputActionReference MovementControl;
    public InputActionReference JumpControl;

    void Start()
    {
        MovementControl.action.Enable();
        JumpControl.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 movement = MovementControl.action.ReadValue<Vector2>();

        input = new Vector3(movement.x, 0, movement.y);
        // check to see if player is on the ground
        
        if (checkGround() == true)
        {

            if (groundcheckHit.transform.gameObject.GetComponent<InteractableObJect>().isInteractable == true)
            {
                
                isGrounded = true;
                triggerJump = false;
                //isDoubleJump = false;
                PMat.dynamicFriction = 1;
                PMat.staticFriction = 1;
                maxSpeed = 10;
                anim.SetBool("IsJump", false);
                anim.SetBool("IsDouble", false);
                Debug.Log(groundcheckHit.transform.gameObject);


                isDoubleJump = false;
                anim.SetBool("IsGrounded", true);
            }

        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
            PMat.dynamicFriction = 0;
            PMat.staticFriction = 0;
            maxSpeed = 7.5f;
            
        }
        //check to see if user press the space bar
        if (JumpControl.action.triggered && triggerJump == false)
        {
            //anim.SetTrigger("Jump");
            triggerJump = true;
            StartCoroutine(Jumping());
            //anim.ResetTrigger("Jump");

        }
    }



    void FixedUpdate()
    {
         
        
        //Store user input as a movement vector
        

        input = Vector3.ClampMagnitude(input, 1);
        if (input != Vector3.zero)
        {
            curSpeed = Mathf.Lerp(curSpeed, maxSpeed, Time.deltaTime*1f);
        }
        else
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, Time.deltaTime*4);

        }


        //get camera forward and right directions
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // make sure camera does not give the character an up value;
        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        // get input based on the direction of the camra
        Vector3 forwardRelativeV = input.z * forward;
        Vector3 forwardRelativeH = input.x * right;

        Vector3 addInput = forwardRelativeH + forwardRelativeV;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + addInput * Time.deltaTime * curSpeed);
        anim.SetFloat("Speed", curSpeed);

        //using inputs find the players rotation direction.
        Vector3 viewdir = transform.position - new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        orientation.forward = viewdir;
        //orientation.forward = viewdir.normalized;

         Vector3 inputDir = orientation.forward * input.z + orientation.right * input.x;


        if(shootie.aimMode == false)
        {

       
            if(inputDir != Vector3.zero)
            {
                //rotate player character;
                playerChar.forward = Vector3.Slerp(playerChar.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        
         }


    }


    
    // check if player is on ground
    bool checkGround()
    {
        Physics.SphereCast(groundpos.position, sphereRadisus, Vector3.down, out groundcheckHit, .1f, mask);




        return Physics.SphereCast(groundpos.position, sphereRadisus, Vector3.down, out groundcheckHit, .1f, mask);

       

    }
    /*
    public int Getsound()
    {
        Physics.SphereCast(groundpos.position, sphereRadisus, Vector3.down, out groundcheckHit, .1f);
        return groundcheckHit.collider.gameObject.GetComponent<InteractableObJect>().soundNumber;
    }

    */

    IEnumerator Jumping()
    {
        triggerJump = true;
            if(isGrounded == true)
            {
                //Debug.Log(groundcheckHit.collider.gameObject.GetComponent<InteractableObJect>().isInteractable);
                if (groundcheckHit.collider.gameObject.GetComponent<InteractableObJect>().isInteractable == true)
                {
                    
                    m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z);
                    m_Rigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
                    particles.Play();
                    anim.SetBool("IsJump", true);
            }
                 else
                  {
                    triggerJump = false;
                    yield return new WaitForSeconds(.1f);
                 }
            }
            else
            {
                if (isDoubleJump == false)
                {

                    anim.SetBool("IsDouble", true);
                    isDoubleJump = true;
                    m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z);
                    m_Rigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
                    particles.Play();
                }
            }

        
        


        yield return new WaitForSeconds(.1f);
        triggerJump = false;
    }

    }
