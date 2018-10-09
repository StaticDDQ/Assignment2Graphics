using UnityEngine;
public class MagnetEffect : ColourEffect {

    private FixedJoint joint;

    public override void ApplyEffect()
    {
        gameObject.layer = 8;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
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

    public override void RevertEffect()
    {
        gameObject.layer = 0;
        base.RevertEffect();
    }
}
