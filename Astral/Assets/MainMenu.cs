using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]Button main;
    [SerializeField] Button control;
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
