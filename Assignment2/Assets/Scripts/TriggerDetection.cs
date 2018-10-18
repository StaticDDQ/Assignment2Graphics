using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField] protected Renderer indicator;
    protected Color currColor;
    protected bool isTriggered = false;

    // Effect where some part of the model change color when triggered
    protected void TransitionEffect()
    {
            indicator.material.SetColor("_EmissionColor", currColor);
    }
}
