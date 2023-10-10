using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //This will have to be modified if there are multiple death areas in a scene
    //Unless all death areas reset to the same spot
    public Transform playerReset;

    void OnTriggerEnter(Collider hit)
    {
        Debug.Log("hit something");
        if (hit.gameObject.tag == "Player")
        {
            //playerReset.position = new Vector3(0, 11, 73);

            hit.gameObject.transform.position = playerReset.position;
        }
    }
}
