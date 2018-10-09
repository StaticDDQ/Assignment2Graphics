using UnityEngine;
public class StaticEffect : ColourEffect {

    // IsKinematic causes the object to remain static
    public override void ApplyEffect()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.tag = "Colourable";
    }

    public override void RevertEffect()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        gameObject.tag = "PickUp";
        base.RevertEffect();
    }
}
