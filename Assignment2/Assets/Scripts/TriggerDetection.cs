using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField] protected Renderer indicator;
    protected bool isTriggered = false;

    // Effect where some part of the model change color when triggered
    protected void TransitionEffect(Color currColor)
    {
        indicator.material.SetColor("_EmissionColor", currColor);
    }
}
