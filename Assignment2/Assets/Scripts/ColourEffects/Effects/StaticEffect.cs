using UnityEngine;
public class StaticEffect : ColourEffect {

    // IsKinematic causes the object to remain static, player also cannot pick up the object
    public override void ApplyEffect()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.tag = "Colourable";
    }

    // colourable tag means player can still colour the object but cannot pick it up, pickup tag can do both
    public override void RevertEffect()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        gameObject.tag = "PickUp";
        Destroy(this);
    }
}
