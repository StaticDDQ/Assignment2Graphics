using System.Collections;
using UnityEngine;

public class Event : MonoBehaviour {

    // Returns true if event ended up successful
    public virtual bool TriggerEvent()
    {
        return true;
    }
}
