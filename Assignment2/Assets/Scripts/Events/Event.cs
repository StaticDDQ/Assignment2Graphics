using UnityEngine;

public abstract class Event : MonoBehaviour {

    // Returns true if event ended up successful
    public abstract bool TriggerEvent();
}
