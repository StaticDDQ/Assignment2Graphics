using UnityEngine;

public class PlacementDetect : TriggerDetection {

    //Simple animation of color being changed when something triggers it

    protected virtual void OnTriggerEnter(Collider other)
    {
        currColor = Color.black;

        StopAllCoroutines();
        StartCoroutine(TransitionEffect());
    }

    private void OnTriggerExit(Collider other)
    {
        currColor = Color.white;

        StopAllCoroutines();
        StartCoroutine(TransitionEffect());
    }
}
