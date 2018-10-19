using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthNormals : MonoBehaviour {

    public Material mat;

	// Use this for initialization
	void Start () {
        Camera.main.depthTextureMode = DepthTextureMode.DepthNormals;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, mat);
    }
}
