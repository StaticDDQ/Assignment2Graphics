using UnityEngine;
public class MagnetEffect : ColourEffect {

    private FixedJoint joint;

    public override void ApplyEffect()
    {
        gameObject.tag = "Magnetic";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Magnetic")
        {
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            joint.enablePreprocessing = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Magnetic")
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }

    public override void RevertEffect()
    {
        gameObject.tag = "Untagged";
        base.RevertEffect();
    }
}
