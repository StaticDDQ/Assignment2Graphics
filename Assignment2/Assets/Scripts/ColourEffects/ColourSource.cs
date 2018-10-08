using UnityEngine;

public class ColourSource : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private Color currColor;

    // Use this for initialization
    void Awake()
    {
        target.GetComponent<Renderer>().material.SetColor("_Color",currColor);
    }

    public Color GetColor()
    {
        return this.currColor;
    }
}
