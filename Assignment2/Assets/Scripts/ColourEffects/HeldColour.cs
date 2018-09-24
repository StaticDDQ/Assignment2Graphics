using UnityEngine;

public class HeldColour : MonoBehaviour {

    private bool isSelected = false;
    private Color currColor = Color.clear;

	public void SelectColor()
    {
        if (!currColor.Equals(Color.clear))
        {
            isSelected = !isSelected;
            // Create an indication of the color being selected
            if (isSelected)
            {
                transform.parent.GetComponent<ColourDecider>().ChangeColor(this);
                // Indicate that it is on
            }
            else
            {
                DeselectColor();
            }
        }
    }

    public void DeselectColor()
    {
        isSelected = false;
        // Indicate that it is off
        transform.parent.GetComponent<ColourDecider>().ChangeColor(null);
    }

    public void AssignColor(Color newColor)
    {
        currColor = newColor;
        // Color the UI
    }

    public void RemoveColor()
    {
        // Remove the color of the UI
        currColor = Color.clear;
        DeselectColor();
    }

    public Color GetCurrColor()
    {
        return this.currColor;
    }
}
