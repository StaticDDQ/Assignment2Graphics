using UnityEngine;
using UnityEngine.SceneManagement;

// Test if the code works
public class TestCode : MonoBehaviour {

    public Color testColor;
    public Color testColor1;
    public Color testColor2;
    public GameObject target3;
    public GameObject target2;
    public GameObject target1;
    public GameObject target;

    public GameObject sceneChange;

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
        if (Input.GetKeyDown(KeyCode.V))
        {
            target.GetComponent<ColourDecider>().SetEffect(testColor1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            target.GetComponent<ColourDecider>().SetEffect(testColor2);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            target2.GetComponent<ButtonDetect>().ButtonPressed();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            target3.GetComponent<PickUp>().SetCarry();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneChange.GetComponent<SceneFade>().BeginFade(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
