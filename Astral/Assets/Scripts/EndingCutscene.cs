using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField]bool PlayerStay;
    [SerializeField]float TimeToEnd;
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject panel1;

    float timerCountDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            PlayerStay = true;
            timerCountDown = TimeToEnd;
        }
    }
    private void Update()
    {
        if(PlayerStay == true)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                // EndCutscene
                director.Play();
                timerCountDown = 0;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            PlayerStay = false;
        }
    }


    public void GameOverScreen()
    {
        SceneManager.LoadScene(3);
    }

}
