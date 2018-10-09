using UnityEngine;
using System.Collections;

public class WeightTrigger : PlacementDetect {

    [SerializeField] private EventRequirements target;
    public bool isOn = false;

    // Used for objects where you need to put something on top of it to trigger an event
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(!isOn && other.tag == "PickUp")
        {
            isOn = true;
            StartCoroutine(ObjControl(other.gameObject));
            target.SendRequirement(true);
        }
    }

    // Used for objects where you need to put something on top of it to trigger an event
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (isOn && other.tag == "PickUp")
        {
            isOn = false;
            target.SendRequirement(false);
        }
    }

    private IEnumerator ObjControl(GameObject obj)
    {
        obj.GetComponent<PickUp>().SetCarry(false);
        obj.tag = "Untagged";
        yield return new WaitForSeconds(1);
        obj.tag = "PickUp";

    }
}
