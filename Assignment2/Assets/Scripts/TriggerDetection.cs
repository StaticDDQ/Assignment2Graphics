using System.Collections;
using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField] protected Renderer indicator;
    protected Color currColor;
    protected bool isTriggered = false;

    // Effect where some part of the model change color when triggered
    protected IEnumerator TransitionEffect()
    {
        float t = 0;
        while (t < 1)
        {
            indicator.material.SetColor("_EmissionColor", Color.Lerp(indicator.material.GetColor("_EmissionColor"), currColor, t));
            t += Time.deltaTime;
            yield return null;
        }
    }
}
