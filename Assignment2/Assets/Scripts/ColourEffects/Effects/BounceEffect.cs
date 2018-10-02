using UnityEngine;

public class BounceEffect : ColourEffect
{
    public override void ApplyEffect()
    {
        // Add a bouncy physics material to the object
        PhysicMaterial bounce = new PhysicMaterial
        {
            bounciness = 0.8f,
            bounceCombine = PhysicMaterialCombine.Maximum
        };

        GetComponent<BoxCollider>().material = bounce;
    }

    public override void RevertEffect()
    {
        GetComponent<BoxCollider>().material = null;
        base.RevertEffect();
    }
}
