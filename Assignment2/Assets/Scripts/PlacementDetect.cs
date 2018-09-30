using UnityEngine;

public class PlacementDetect : TriggerDetection {

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Do something
        currColor = Color.black;

        StopAllCoroutines();
        StartCoroutine(TransitionEffect());
    }

    private void OnTriggerExit(Collider other)
    {
        // Do something else
        currColor = Color.white;

        StopAllCoroutines();
        StartCoroutine(TransitionEffect());
    }
}
