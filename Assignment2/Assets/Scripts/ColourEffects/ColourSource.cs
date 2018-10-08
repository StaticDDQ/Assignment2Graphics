using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSource : MonoBehaviour {

    [SerializeField] private Color currColor;

    // Use this for initialization
    void Awake()
    {
        GetComponent<Renderer>().material.SetColor("_Color",currColor);
    }

    public Color GetColor()
    {
        return this.currColor;
    }
}
