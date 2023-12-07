using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField]Button main;
    [SerializeField] Button control;

    private void Start()
    {
        
    }
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ExtraMusic");
        foreach (GameObject enemy in objs)
        {
            DestroyObject(enemy);
        }
    }
    public void playGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void ToControls()
    {
        control.Select();
    }
    public void toMain()
    {
        main.Select();
    }
}
