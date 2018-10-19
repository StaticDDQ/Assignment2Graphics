using UnityEngine;
using System.Collections;

public class WeightTrigger : PlacementDetect {

    [SerializeField] private Event target;
    [SerializeField] private float waitTime = 1;

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

    // trigger an event if pickup object is out of the trigger
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (isTriggered && other.tag == "PickUp")
        {
            isTriggered = false;
            target.TriggerEvent();
        }
    }

    // immediately stops the object if it lands on the trigger
    // wait for event to finish before being able to grab the object again
    private IEnumerator ObjControl(GameObject obj)
    {
        obj.GetComponent<PickUp>().SetCarry(false);
        obj.tag = "Untagged";
        obj.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(waitTime);
        obj.tag = "PickUp";
        obj.GetComponent<Rigidbody>().isKinematic = false;

    }
}
