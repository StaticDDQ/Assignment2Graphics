using UnityEngine;

// Attach this to the object that needs to be colored
public class ColourDecider : MonoBehaviour {

    [SerializeField] private Color currColor = Color.white;

    // Setting the color to the object, apply effect based on color
    public void SetEffect(Color newColor)
    {
        // Change color to white entirely, reset the color
        if (newColor == Color.white)
            currColor = Color.white;
        // Start with new color
        else if (currColor == Color.white)
            currColor = newColor;
        // Color is mixed together
        else
            currColor = (currColor + newColor);

        // Applying the same color again will enlarge/shrink the object more
        if ((GetComponent<EnlargeEffect>() != null && currColor == Color.red) ||
            (GetComponent<ShrinkEffect>() != null && currColor == Color.blue))
        {
            GetComponent<ColourEffect>().ApplyEffect();
        }
        // If theres already an effect, remove it and replace it with another
        else if (GetComponent<ColourEffect>() != null)
        {
            GetComponent<ColourEffect>().RevertEffect();
            ColourAssociate.SelectColor(gameObject, currColor);
        }
        else
        {
            ColourAssociate.SelectColor(gameObject, currColor);
        }
    }
}
