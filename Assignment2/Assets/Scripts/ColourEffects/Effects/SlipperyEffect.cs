using UnityEngine;

public class SlipperyEffect : ColourEffect {

    private float initMass;

    public override void ApplyEffect()
    {
        // Simply apply a slippery physics material to an object
        initMass = GetComponent<Rigidbody>().mass;

        GetComponent<Rigidbody>().mass = 0.01f;
        GetComponent<Rigidbody>().angularDrag = 0f;
        PhysicMaterial slippery = new PhysicMaterial
        {
            dynamicFriction = 0.005f,
            staticFriction = 0,
            frictionCombine = PhysicMaterialCombine.Minimum
        };

        GetComponent<Collider>().material = slippery;
    }

    public override void RevertEffect()
    {
        GetComponent<Rigidbody>().mass = initMass;
        GetComponent<Rigidbody>().angularDrag = 0.5f;
        GetComponent<Collider>().material = null;
        base.RevertEffect();
    }
}
