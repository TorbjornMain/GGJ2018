using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementShaderScript : MonoBehaviour {

    public Shader ReplacementShader;

    public bool shaderActive = false;
	
    void Start()
    {
        ToggleShader();
    }

    public void ToggleShader()
    {
        shaderActive = !shaderActive;
        GetComponent<Camera>().SetReplacementShader(shaderActive ? ReplacementShader : null, "Visibility");
    }

}
