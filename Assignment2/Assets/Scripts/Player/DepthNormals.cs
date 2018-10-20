using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthNormals : MonoBehaviour {

    public Material mat;

	// Use this for initialization
	void Start () {
        // Camera has access to depth and normals of pixels on screen
        Camera.main.depthTextureMode = DepthTextureMode.DepthNormals;
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        // Allow material to access depth and normals
        Graphics.Blit(source, destination, mat);
    }
}
