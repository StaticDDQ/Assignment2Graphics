using UnityEngine;

// Test if the code works
public class TestCode : MonoBehaviour {

    public Color testColor;
    public GameObject target2;
    public GameObject target1;
    public GameObject target;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            target1.GetComponent<DissolveObject>().DissolveOn();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            target.GetComponent<ColourDecider>().SetEffect(testColor);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            target2.GetComponent<ButtonDetect>().ButtonPressed();
        }
    }
}
