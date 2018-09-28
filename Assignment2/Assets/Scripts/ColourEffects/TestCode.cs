using UnityEngine;

// Test if the code works
public class TestCode : MonoBehaviour {
    public GameObject target1;

    private bool isOn = true;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!isOn)
                target1.GetComponent<DissolveObject>().DissolveOn();
            else
                target1.GetComponent<DissolveObject>().DissolveOff();
            isOn = !isOn;
        }
	}
}
