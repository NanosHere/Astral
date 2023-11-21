using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCutscenes : MonoBehaviour
{
    public Animator animator;
    int SceneNumber = -1;

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

}
