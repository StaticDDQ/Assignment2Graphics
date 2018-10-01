﻿using UnityEngine;

// Attach this to the object that needs to be colored
public class ColourDecider : MonoBehaviour {

    [SerializeField] private Color currColor = Color.white;

    // Setting the color to the object, apply effect based on color
    public void SetEffect(Color newColor)
    {
        // Change color to white and remove the effect
        if (newColor == Color.white)
        {
            currColor = Color.white;
            if (GetComponent<ColourEffect>() != null)
                GetComponent<ColourEffect>().RevertEffect();
            return;
        }
        // Start with new color
        else if (currColor == Color.white)
            currColor = newColor;
        // Color is mixed together if color is not the same
        else if (currColor != newColor)
        {
            currColor = (currColor + newColor);
            currColor.a = 1;
        }

        // Applying the same color again will enlarge/shrink the object more
        if ((GetComponent<EnlargeEffect>() != null && newColor == Color.red) ||
            (GetComponent<ShrinkEffect>() != null && newColor == Color.blue))
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
