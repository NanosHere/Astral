using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMainMenu : MonoBehaviour
{
    [SerializeField] Button main;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        main.Select();
    }
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }
}
