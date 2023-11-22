using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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


    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EffectMenu();
        }

        if(playShoot.aimMode == true)
        {
            ShootCanvas.SetActive(true);
        }
        else
        {
            ShootCanvas.SetActive(false);
        }

        LampText.SetText((3-playShoot.lampsOut).ToString());
    }


    public void ToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void ToControls()
    {
        if(controlsOpen == true)
        {
            controls.SetActive(false);
            controlsOpen = false;
        }
        else
        {
            controls.SetActive(true);
            controlsOpen = true;
        }
    }

    public void ToCollection()
    {
        if(collectionOpen == true)
        {
            collectionCanvas.SetActive(false);
            collectionOpen = false;
        }
        else
        {
            collectionCanvas.SetActive(true);
            collectionOpen = true;
        }
    }
    public void EffectMenu()
    {
        if (MenuOpen == true)
        {
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

            ShootCanvas.SetActive(false);
            hudcanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MenuOpen = true;
            Time.timeScale = 0;
        }
    }
}
