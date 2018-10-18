using UnityEngine;

public class PlacementDetect : TriggerDetection {

    //Simple animation of color being changed when something triggers it

    protected virtual void OnTriggerEnter(Collider other)
    {
        currColor = Color.black;

        TransitionEffect();
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        currColor = Color.white;

        TransitionEffect();
    }
}
