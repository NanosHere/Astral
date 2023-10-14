using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    public Transform orientation;
    public Transform playerChar;

    public float rotationSpeed;
    public ShootControler shootie;

    //jump stuff
    [Header("jump")]

    public float jumpSpeed =10;
    private bool isGrounded;
    public Transform groundpos;
    public LayerMask mask;
    public float sphereRadisus;
    public RaycastHit groundcheckHit;
    private Transform extraOrientation;

    
    

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
         
        
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        //get camera forward and right directions
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // make sure camera does not give the character an up value;
        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        // get input based on the direction of the camra
        Vector3 forwardRelativeV = m_Input.z * forward;
        Vector3 forwardRelativeH = m_Input.x * right;

        Vector3 addInput = forwardRelativeH + forwardRelativeV;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + addInput * Time.deltaTime * m_Speed);

        //using inputs find the players rotation direction.
        Vector3 viewdir = transform.position - new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        orientation.forward = viewdir;
        //orientation.forward = viewdir.normalized;

         Vector3 inputDir = orientation.forward * m_Input.z + orientation.right * m_Input.x;


        if(shootie.aimMode == false)
        {

       
            if(inputDir != Vector3.zero)
            {
                //rotate player character;
                playerChar.forward = Vector3.Slerp(playerChar.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        
         }




        Debug.Log(checkGround());

        //jump script + check ground
        if (Input.GetKey(KeyCode.Space) && checkGround())
        {
            m_Rigidbody.velocity += jumpSpeed * Vector3.up;
        }
        




    }
    
    // check if player is on ground
    bool checkGround()
    {
        return Physics.SphereCast(groundpos.position, sphereRadisus, Vector3.down, out groundcheckHit, .1f);
    }
}
