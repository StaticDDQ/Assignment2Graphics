using UnityEngine;
public class EnlargeEffect : ColourEffect {

    private Vector3 baseScale;
    private bool isEnlarge = false;

    public override void ApplyEffect()
    {
        if (!isEnlarge)
        {
            isEnlarge = true;
            baseScale = transform.localScale;
        }
        transform.localScale *= 2;
    }

    public override void RevertEffect()
    {
        isEnlarge = false;
        transform.localScale = baseScale;
    }
}
