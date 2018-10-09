using UnityEngine;

public class PlacementDetect : TriggerDetection {

    //Simple animation of color being changed when something triggers it

    protected virtual void OnTriggerEnter(Collider other)
    {
        currColor = Color.black;

        StartCoroutine(TransitionEffect());
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        currColor = Color.white;

        StartCoroutine(TransitionEffect());
    }
}
