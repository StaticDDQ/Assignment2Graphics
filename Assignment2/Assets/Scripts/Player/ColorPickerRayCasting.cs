using UnityEngine;
using UnityEngine.UI;

public class ColorPickerRayCasting : MonoBehaviour {

    public Color colorPreview;
    public Renderer source;

    private RaycastHit hit;
    private bool hasColor = false;
    [SerializeField] private float distanceToSee=3;
	
	// Update is called once per frame
	void Update ()
    {
        // Right click to grab color
        if (Input.GetMouseButton(1) && Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee) && hit.collider.tag == "Source")
        {
            var material = hit.collider.GetComponent<Renderer>().material;
            Color c = material.color;

            var tex2D = material.mainTexture as Texture2D;
            if (tex2D != null)
            {
                c = tex2D.GetPixelBilinear(hit.textureCoord[0], hit.textureCoord[1]);
            }
            hasColor = true;
            colorPreview = c;
            source.material.SetColor("_EmissionColor", c);
        }
	}
}
