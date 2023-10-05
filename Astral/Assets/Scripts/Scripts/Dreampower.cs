using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreampower : MonoBehaviour
{
    public Shader shade;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Shader.PropertyToID("SimpleDisolvesize"));
        Shader.SetGlobalFloat(Shader.PropertyToID("SimpleDisolvesize"), 2);
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat(Shader.PropertyToID("SimpleDisolvesize"), 2);
    
}
}
