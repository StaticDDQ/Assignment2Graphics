using UnityEngine;

public class BounceEffect : ColourEffect
{
    private AudioClip currClip;
    private AudioClip bounceClip;
    public override void ApplyEffect()
    {
        if(bounceClip == null && currClip == null)
        {
            currClip = GetComponent<AudioSource>().clip;
            bounceClip = Resources.Load<AudioClip>("bounce");
            Debug.Log(bounceClip);
        }

        GetComponent<AudioSource>().clip = bounceClip;
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
        GetComponent<AudioSource>().clip = currClip;
        GetComponent<BoxCollider>().material = null;
        base.RevertEffect();
    }
}
