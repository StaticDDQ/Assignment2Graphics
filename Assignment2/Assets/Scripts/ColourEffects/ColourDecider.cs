using UnityEngine;

public class ColourDecider : MonoBehaviour {

    [SerializeField] private Color currColor = Color.white;

    // Setting the color to the object, apply effect based on color
    public void SetEffect(Color newColor)
    {
        // Change color to white entirely
        if (newColor == Color.white)
            currColor = Color.white;
        // Start with new color
        else if (currColor == Color.white)
            currColor = newColor;
        // Color is mixed
        else
            currColor = (currColor + newColor);

        if ((GetComponent<EnlargeEffect>() != null && currColor == Color.red) ||
            (GetComponent<ShrinkEffect>() != null && currColor == Color.blue))
        {
            GetComponent<ColourEffect>().ApplyEffect();
        }
        else if (GetComponent<ColourEffect>() != null)
        {
            // Remove the first effect and replace with the new one
            GetComponent<ColourEffect>().RevertEffect();
            ColourAssociate.SelectColor(gameObject, currColor);
        }
        else
        {
            ColourAssociate.SelectColor(gameObject, currColor);
        }
    }
}
