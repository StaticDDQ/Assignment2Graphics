using UnityEngine;
public class MagnetEffect : ColourEffect {

    private FixedJoint joint;

    // change layermask to "Magnetic"
    public override void ApplyEffect()
    {
        gameObject.layer = 8;
    }

    // will have this object stick to any object that has the "Magnetic" layermask
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            // Used so that it will the objects will always stick together even if one is moved around
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            joint.enablePreprocessing = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }

    // changed the layermask back to default
    public override void RevertEffect()
    {
        gameObject.layer = 0;
        // If there is still a fixed joint, can happen if effect is removed
        if(gameObject.GetComponent<FixedJoint>() != null)
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
        Destroy(this);
    }
}
