using UnityEngine;

// Global static class used for checking
public static class ColourAssociate {

    // Use this over Color.yellow to allow easier color comparison
    private static Color YELLOW = new Vector4(1, 1, 0, 1);

    // Keep track what color is associated with an effect
	public static void SelectColor(GameObject obj, Color newColor)
    {
        if (newColor == Color.red)
        { 
            obj.AddComponent<EnlargeEffect>();
        }
        else if (newColor == Color.green)
        {
            obj.AddComponent<StaticEffect>();
        }
        else if (newColor == Color.blue)
        {
            obj.AddComponent<ShrinkEffect>();
        }
        else if (newColor == YELLOW)
        {
            obj.AddComponent<MagnetEffect>();
        }
        else if (newColor == Color.cyan)
        {
            obj.AddComponent<SlipperyEffect>();
        }
        else if (newColor == Color.magenta)
        {
            obj.AddComponent<BounceEffect>();
        }
        else if (newColor == Color.white)
        {
            obj.AddComponent<RemoveEffect>();
        }
    }
}
