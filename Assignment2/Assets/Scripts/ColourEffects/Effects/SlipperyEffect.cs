using UnityEngine;

public class SlipperyEffect : ColourEffect {

    public override void ApplyEffect()
    {
        // Simply apply a slippery physics material to an object
        if(gameObject.tag != "Floor")
        {
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
        // If its a floor, any object that comes in contact with it will slip
        else
        {

        }
    }

    public override void RevertEffect()
    {
        if(gameObject.tag != "Floor")
        {
            GetComponent<Collider>().material = null;
        }
        else
        {

        }
        base.RevertEffect();
    }
}
