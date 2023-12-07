using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CangeBetweenCotrol : MonoBehaviour
{

    public GameObject controlsController;
    public GameObject controlsKeyboard;
    public Button controlerbutton;
    public Button keyboardbutton;

    [SerializeField] bool Controller = false;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

    public void changeControls()
    {
        if(Controller == false)
        {

            // keyboard menu
            Controller = true;
            
            controlerbutton.Select();
            controlsKeyboard.gameObject.SetActive(false);
            controlsKeyboard.gameObject.SetActive(true);
        }
        else
        {
            // controller menu
            Controller = false;
            keyboardbutton.Select();
            controlsKeyboard.gameObject.SetActive(false);
            controlsKeyboard.gameObject.SetActive(true);
        }



    }



}
