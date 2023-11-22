using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCutscenes : MonoBehaviour
{
    public Animator animator;
    public int SceneNumber;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }
    public void PrintEvent(int current)
    {
        //animator.SetInteger("Cutscene", 0);
    }
    public void ChangeScene()
    {
        SceneNumber++;
        animator.SetInteger("Cutscene", SceneNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            animator.SetInteger("Cutscene", SceneNumber);
        }
    }

}
