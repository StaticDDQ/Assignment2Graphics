using UnityEngine;
using System.Collections;

public class WeightTrigger : PlacementDetect {

    [SerializeField] private Event target;

    // Used for objects where you need to put something on top of it to trigger an event
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        GetComponent<AudioSource>().Play();

        if(!isTriggered && other.tag == "PickUp")
        {
            isTriggered = true;
            StartCoroutine(ObjControl(other.gameObject));
            target.TriggerEvent();
        }
    }

    // Used for objects where you need to put something on top of it to trigger an event
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (isTriggered && other.tag == "PickUp")
        {
            isTriggered = false;
            target.TriggerEvent();
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
