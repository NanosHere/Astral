using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HudControl : MonoBehaviour
{

    public ShootControler playShoot;
    public GameObject ShootCanvas;
    public GameObject hudcanvas;
    public GameObject pauseCanvas;
    public GameObject controls;
    public GameObject collectionCanvas;
    public  TextMeshProUGUI LampText;
    public bool controlsOpen;
    public bool MenuOpen;
    public bool collectionOpen;

    [Header("Input")]
     public InputActionReference menuControls;
    public InputActionReference jumpControls;

    [Header("buttons")]
    public Button controlButton;
    public Button collectionButton;
    public Button collectionBackButton;
    public Button controlBackButton;
    public Button resumeButton;

    [Header("lamps")]
    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Lamp3;

    // Start is called before the first frame update
    void Start()
    {
        menuControls.action.Enable();
        ShootCanvas.SetActive(true);
        hudcanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        collectionCanvas.SetActive(false);
        controls.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // menu action trigger
        if (menuControls.action.triggered)
        {
            EffectMenu();
        }

        // aim mode controls
        if(playShoot.aimMode == true)
        {
            ShootCanvas.SetActive(true);
        }
        else
        {
            ShootCanvas.SetActive(false);
        }


        switch (3 - playShoot.lampsOut)
        {
            case 0:
                Lamp1.SetActive(false);
                Lamp2.SetActive(false);
                Lamp3.SetActive(false);

                break;
            case 1:
                Lamp1.SetActive(true);
                Lamp2.SetActive(false);
                Lamp3.SetActive(false);
                break;
            case 2:
                Lamp1.SetActive(true);
                Lamp2.SetActive(true);
                Lamp3.SetActive(false);
                break;
            case 3:
                Lamp1.SetActive(true);
                Lamp2.SetActive(true);
                Lamp3.SetActive(true);
                break;

        }

        LampText.SetText((3-playShoot.lampsOut).ToString());
    }


    public void ToHome()
    {
        SceneManager.LoadScene(0);
    }

    // open control menu
    public void ToControls()
    {
        if(controlsOpen == true)
        {
            controlButton.Select();
            controls.SetActive(false);
            controlsOpen = false;
        }
        else
        {
            controlBackButton.Select();
            
            controls.SetActive(true);
            controlsOpen = true;
        }
    }

    // open collection menu
    public void ToCollection()
    {
        if(collectionOpen == true)
        {
            collectionButton.Select();
            collectionCanvas.SetActive(false);
            collectionOpen = false;
        }
        else
        {
            collectionBackButton.Select();
           
            collectionCanvas.SetActive(true);
            collectionOpen = true;
        }
    }
    public void EffectMenu()
    {
        if (MenuOpen == true)
        {

            //pause is off

            jumpControls.action.Enable();
            controlsOpen = false;
            controls.SetActive(false);
            ShootCanvas.SetActive(true);
            hudcanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            MenuOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            collectionCanvas.SetActive(false);
            collectionOpen = false;

        }
        else
        {

            // pause is on

            jumpControls.action.Disable();
            ShootCanvas.SetActive(false);
            hudcanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MenuOpen = true;
            Time.timeScale = 0;
            resumeButton.Select();
        }
    }

   

}
