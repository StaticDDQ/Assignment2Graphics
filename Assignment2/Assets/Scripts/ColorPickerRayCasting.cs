using UnityEngine;
using UnityEngine.UI;

public class ColorPickerRayCasting : MonoBehaviour {

    public Image colorPreview;

    RaycastHit hit;
    public float distanceToSee=3;
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if(Input.GetMouseButton(1) && Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {

            var material = hit.collider.GetComponent<Renderer>().material;
            Color c = material.color;

            var tex2D = material.mainTexture as Texture2D;
            if (tex2D != null)
            {
                c = tex2D.GetPixelBilinear(hit.textureCoord[0], hit.textureCoord[1]);
            }

            colorPreview.color = new Color(c.r, c.g, c.b);
        }
	}
}
