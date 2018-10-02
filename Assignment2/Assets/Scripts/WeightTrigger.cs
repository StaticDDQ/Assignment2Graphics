using UnityEngine;

public class WeightTrigger : PlacementDetect {

    [SerializeField] private EventRequirements target;

    // Used for objects where you need to put something on top of it to trigger an event
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        target.SendRequirement(other.gameObject);
    }
}
