﻿using UnityEngine;

// Attach this to the object that needs to be colored
public class ColourDecider : MonoBehaviour {

    [SerializeField] private Color currColor = Color.white;
    private bool reverting = false;

    // Assign new effect once the previous one has been removed
    private void Update()
    {
        if(reverting && GetComponent<ColourEffect>() == null)
        {
            reverting = false;
            // will not add effect if currColor is white
            if (currColor != Color.white)
            {
                ColourAssociate.SelectColor(gameObject, currColor);
            }
        }
    }

    // Setting the color to the object, apply effect based on color
    public bool SetEffect(Color newColor)
    {
        // If color is being reverted, dont assign effect yet
        if (reverting)
            return false;

        #region AssignColor
        // Change color to white and remove the effect
        if (newColor == Color.white)
        {
            currColor = Color.white;
            if (GetComponent<ColourEffect>() != null)
            {
                GetComponent<ColourEffect>().RevertEffect();
                reverting = true;
            }
        }
        // if current color is white, assign a new color
        else if (currColor == Color.white)
        {
            currColor = newColor;
        }
        // mix the color together
        else if (currColor != newColor)
        {
            currColor = (currColor + newColor);
            currColor.a = 1;
        }

        GetComponent<Renderer>().material.SetColor("_Color", currColor);
        #endregion

        #region ScaleEffect
        // Applying the same color again will enlarge/shrink the object more
        if ((GetComponent<EnlargeEffect>() != null && newColor == Color.red) ||
            (GetComponent<ShrinkEffect>() != null && newColor == Color.blue))
        {
            GetComponent<ColourEffect>().ApplyEffect();
        }
        #endregion

        #region AssignEffect
        else if (ColourAssociate.ValidColor(currColor))
        {
            // If theres already an effect, remove it and replace it with another
            if (GetComponent<ColourEffect>() != null)
            {
                GetComponent<ColourEffect>().RevertEffect();
                reverting = true;
            }
            else
            {
                ColourAssociate.SelectColor(gameObject, currColor);
            }
        }
        
        #endregion

        return true;
    }
}
