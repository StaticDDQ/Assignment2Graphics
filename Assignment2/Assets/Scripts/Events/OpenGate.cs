using System.Collections;
using UnityEngine;

public class OpenGate : Event {

    // Components for the event
    [SerializeField] private GameObject fence1;
    [SerializeField] private GameObject fence2;
    [SerializeField] private GameObject dissolvedWall;

    // Check if the gate is opened or not
    private bool isOn = false;
    // Animation is finished or not
    private bool finishAnim = true;

    // Event that either open the gate or close it
    public override bool TriggerEvent()
    {
        // If the object is currently not being dissolved and animation is done playing
        if (finishAnim && !dissolvedWall.GetComponent<DissolveObject>().GetIsOn())
        {
            finishAnim = false;
            if (!isOn)
                StartCoroutine(GateOn());
            else
                StartCoroutine(GateOff());

            isOn = !isOn;

            return true;
        }

        // the first event was not fully finished
        return false;
    }

    private IEnumerator GateOn()
    {
        dissolvedWall.GetComponent<DissolveObject>().SendRequirement(false);

        yield return new WaitForSeconds(1);

        fence1.GetComponent<Animator>().Play("FenceOpen");
        fence2.GetComponent<Animator>().Play("FenceOpen");

        finishAnim = true;
    }

    private IEnumerator GateOff()
    {
        fence1.GetComponent<Animator>().Play("FenceClose");
        fence2.GetComponent<Animator>().Play("FenceClose");

        yield return new WaitForSeconds(1);

        dissolvedWall.GetComponent<DissolveObject>().SendRequirement(true);

        finishAnim = true;
    }
}
