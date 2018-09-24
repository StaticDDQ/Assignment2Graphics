using UnityEngine;

public static class ColourAssociate {

	public static ColourEffect SelectColor(Color newColor)
    {
        if (newColor.Equals(Color.red))
        {
            return new EnlargeEffect();
        }
        else if (newColor.Equals(Color.green))
        {
            return new StaticEffect();
        }
        else if (newColor.Equals(Color.blue))
        {
            return new ShrinkEffect();
        }
        else if (newColor.Equals(Color.yellow))
        {
            return new MagnetEffect();
        }
        else if (newColor.Equals(Color.cyan))
        {
            return new SlipperyEffect();
        }
        else if (newColor.Equals(Color.magenta))
        {
            return new BounceEffect();
        }
        else if (newColor.Equals(Color.white))
        {
            return new RemoveEffect();
        }

        return null;
    }
}
