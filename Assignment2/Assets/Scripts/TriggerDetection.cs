using UnityEngine;
using System.Collections;

public class TriggerDetection : MonoBehaviour {

    [SerializeField] protected Renderer indicator;
    protected Color currColor;
    protected bool isTriggered = false;

    // Effect where some part of the model change color when triggered
    protected IEnumerator TransitionEffect()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f) {
            indicator.material.SetColor("_EmissionColor", Color.Lerp(indicator.material.GetColor("_EmissionColor"), currColor,elapsedTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
