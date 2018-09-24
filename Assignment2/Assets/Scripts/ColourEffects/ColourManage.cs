using UnityEngine;

public class ColourManage : MonoBehaviour {

    private Color currColor = Color.white;

    // Setting the color to the object, apply effect based on color
	public void SetEffect(Color newColor)
    {
        if (!newColor.Equals(Color.white))
            currColor = (currColor + newColor) * 0.5f;
        else
            currColor = Color.white;

        ColourEffect effect = ColourAssociate.SelectColor(currColor);
    }
}
