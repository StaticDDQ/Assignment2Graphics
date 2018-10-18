using UnityEngine;

public class SlipperyEffect : ColourEffect {

    public override void ApplyEffect()
    {
        // Simply apply a slippery physics material to an object

        PhysicMaterial slippery = new PhysicMaterial
        {
            dynamicFriction = 0f,
            staticFriction = 0,
            frictionCombine = PhysicMaterialCombine.Multiply
        };

        GetComponent<Collider>().material = slippery;
    }

    public override void RevertEffect()
    {
        GetComponent<Collider>().material = null;
        Destroy(this);
    }
}
