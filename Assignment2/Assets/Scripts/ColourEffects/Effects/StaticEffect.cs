using UnityEngine;
public class StaticEffect : ColourEffect {

    // IsKinematic causes the object to remain static
    public override void ApplyEffect()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void RevertEffect()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        base.RevertEffect();
    }
}
