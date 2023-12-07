using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    public AudioSource mainaudio;
    public AudioClip ending;
    [SerializeField]float duration;
    [SerializeField] float targetVolume;
    // Start is called before the first frame update
    


    private void Awake()
    {
        
        
    }

    private void Start()
    {
        
    }
    public void PlayMusic()
    {
        mainaudio.clip = ending;
        DontDestroyOnLoad(this.transform.gameObject);
        mainaudio.Play();
    }

    public void StopMusic()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IntroMusic");
        foreach (GameObject enemy in objs)
        {
            
            StartCoroutine(FadeAudio(enemy.gameObject.GetComponent<AudioSource>(), targetVolume, duration, enemy));

        }

       

    }


 

    public void Muteaudio()
    {
        mainaudio.Stop();
       
        

    }

    // Ref : https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#:~:text=There%27s%20no%20separate%20function%20for,script%20will%20do%20the%20rest.
    public static IEnumerator FadeAudio(AudioSource main, float target, float duration, GameObject enemy)
    {
        float currentTime = 0;
        float start = main.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            main.volume = Mathf.Lerp(start, target, currentTime / duration);
            yield return null;
        }
        DestroyObject(enemy);
        yield break;

        
    }


}
