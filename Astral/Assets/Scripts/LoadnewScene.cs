using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadnewScene : MonoBehaviour
{
    // Start is called before the first frame update
   
        private Scene scene;

    private void Start()
    {
       // var parameters = new LoadSceneParameters(LoadSceneMode.Additive);

       // scene = SceneManager.LoadScene(2, parameters);
       // Debug.Log("Load 1 of scene2: ");
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScenes()
    {
        SceneManager.LoadScene(2);

    }
}
