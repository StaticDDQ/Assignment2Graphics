using UnityEngine;

// Attachments for objects
public class ColourEffect : MonoBehaviour {

    // When interacted, apply given effect based on the color
    public virtual void ApplyEffect(){}

    // If the effect were to be removed
    public virtual void RevertEffect()
    {
        Destroy(this);
    }
}
