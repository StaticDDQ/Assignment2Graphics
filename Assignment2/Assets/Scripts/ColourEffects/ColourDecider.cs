using System.Collections.Generic;
using UnityEngine;

public class ColourDecider : MonoBehaviour {

    [SerializeField] private List<HeldColour> currColors;
    private HeldColour selectedColor;

    // Add new color if possible for a max of 4
    public bool AddColor(Color newColor)
    {
        for (int i = 0; i < 4; i++)
        {
            if (currColors[i].GetCurrColor().Equals(Color.clear))
            {
                currColors[i].AssignColor(newColor);
                return true;
            }
        }
        return false;
    }

    // If a color is selected, deselect the previous selected color
    public void ChangeColor(HeldColour newSelected)
    {
        if(selectedColor != null){
            selectedColor.DeselectColor();
        }
        selectedColor = newSelected;
    }

    // Assign effect to object if a color is selected
    public Color GetSelectedEffect()
    {
        if(selectedColor != null)
            return selectedColor.GetCurrColor();

        return Color.clear;
    }
}
