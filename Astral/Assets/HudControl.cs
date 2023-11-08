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
    public GameObject contols;
    public  TextMeshProUGUI LampText;
    public bool controlsOpen;
    public bool MenuOpen;


    // Start is called before the first frame update
    void Start()
    {
        ShootCanvas.SetActive(true);
        hudcanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        contols.SetActive(false);
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
            contols.SetActive(false);
            controlsOpen = false;
        }
        else
        {
            contols.SetActive(true);
            controlsOpen = true;
        }
    }

    public void EffectMenu()
    {
        if (MenuOpen == true)
        {
            controlsOpen = false;
            contols.SetActive(false);
            ShootCanvas.SetActive(true);
            hudcanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            MenuOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

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
