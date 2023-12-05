using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHint : MonoBehaviour
{
    public AudioSource audioPlayer;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("SOUND!!");
            audioPlayer.Play();
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        audioPlayer.Stop();
    }
}
