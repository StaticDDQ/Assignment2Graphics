using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField] private Renderer indicator;

    private void OnTriggerEnter(Collider other)
    {
        //Do something
        indicator.material.SetColor("_EmissionColor", new Color(0, 0, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        // Do something else
        indicator.material.SetColor("_EmissionColor", new Color(1, 1, 1));
    }
}
