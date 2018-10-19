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
            // access the audio clip inside the Resources folder
            bounceClip = Resources.Load<AudioClip>("bounce");
        }

        // change the audio so it makes a bounce sound when hitting the floor
        GetComponent<AudioSource>().clip = bounceClip;
        
        // Add a bouncy physics material to the object
        PhysicMaterial bounce = new PhysicMaterial
        {
            bounciness = 0.95f,
            bounceCombine = PhysicMaterialCombine.Maximum
        };

        GetComponent<BoxCollider>().material = bounce;
    }

    public override void RevertEffect()
    {
        // remove material and change the audio back to normal
        GetComponent<AudioSource>().clip = currClip;
        GetComponent<BoxCollider>().material = null;

        Destroy(this);
    }
}
