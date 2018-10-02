using UnityEngine;

// Attach this to the object that needs to be colored
public class ColourDecider : MonoBehaviour {

    [SerializeField] private Color currColor = Color.white;
    private bool reverting = false;

    private void Update()
    {
        if(reverting && GetComponent<ColourEffect>() == null)
        {
            reverting = true;
            ColourAssociate.SelectColor(gameObject, currColor);
        }
    }

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
        else if (currColor == Color.white)
            currColor = newColor;
        else
        {
            currColor = (currColor + newColor);
            currColor.a = 1;
        }

        #region ScaleEffect
        // Applying the same color again will enlarge/shrink the object more
        if ((GetComponent<EnlargeEffect>() != null && newColor == Color.red) ||
            (GetComponent<ShrinkEffect>() != null && newColor == Color.blue))
        {
            GetComponent<ColourEffect>().ApplyEffect();
            return;
        }
        #endregion

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
}
