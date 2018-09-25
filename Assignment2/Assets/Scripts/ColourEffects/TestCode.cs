using UnityEngine;

// Test if the code works
public class TestCode : MonoBehaviour {

    public GameObject target;
    public Color selectColor;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            target.GetComponent<Renderer>().material.color = selectColor;
            target.GetComponent<ColourDecider>().SetEffect(selectColor);
        }
	}
}
