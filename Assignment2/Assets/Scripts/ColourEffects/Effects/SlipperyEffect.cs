using UnityEngine;

public class SlipperyEffect : ColourEffect {

    private float force = 5f;

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
