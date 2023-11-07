using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudControl : MonoBehaviour
{

    public ShootControler playShoot;
    public GameObject ShootCanvas;
    public  TextMeshProUGUI LampText;
    public bool MenuOpen;


    // Start is called before the first frame update
    void Start()
    {
        
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

        LampText.SetText(playShoot.lampsOut.ToString());
    }


    public void EffectMenu()
    {
        if (MenuOpen == true)
        {
            Time.timeScale = 1;
            MenuOpen = false;
            
        }
        else
        {
            MenuOpen = true;
            Time.timeScale = 0;
        }
    }
}
