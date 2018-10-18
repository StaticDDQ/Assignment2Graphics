using UnityEngine;

public class PlacementDetect : TriggerDetection {

    //Simple animation of color being changed when something triggers it

    protected virtual void OnTriggerEnter(Collider other)
    {
        TransitionEffect(Color.black);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        TransitionEffect(Color.white);
    }
}
