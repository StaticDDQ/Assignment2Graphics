using UnityEngine;

public class SlipperyEffect : ColourEffect {

    private float force = 4f;

    public override void ApplyEffect()
    {
        // Simply apply a slippery physics material to an object

        PhysicMaterial slippery = new PhysicMaterial
        {
            dynamicFriction = 0.05f,
            staticFriction = 0.05f,
            frictionCombine = PhysicMaterialCombine.Multiply
        };

        GetComponent<Collider>().material = slippery;
    }

    // add a force whenever the player touches the object
    // to show the slippery effect easier
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
        }
    }

    public override void RevertEffect()
    {
        GetComponent<Collider>().material = null;
        Destroy(this);
    }
}
