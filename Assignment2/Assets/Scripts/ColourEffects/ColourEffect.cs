using UnityEngine;

public class ColourEffect : MonoBehaviour {

    // Each effect is associated with different color
    [SerializeField] protected Color color;
    protected bool effectOn = false;

    // When interacted, apply given effect based on the color
    public virtual void ApplyEffect() {
        effectOn = true;
    }

    // If the effect were to be removed
    public virtual void RevertEffect() {
        effectOn = false;
    }

    public Color GetColor()
    {
        return this.color;
    }
}
