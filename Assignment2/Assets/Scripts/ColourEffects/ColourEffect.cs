using UnityEngine;

abstract public class ColourEffect : MonoBehaviour {

    // When interacted, apply given effect based on the color
    public abstract void ApplyEffect();

    // If the effect were to be removed
    public abstract void RevertEffect();
}
