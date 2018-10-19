using UnityEngine;

public class RaycastInteraction : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField] private float distanceToSee = 3;
    private bool isCarrying = false;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            // pick up an object similar to how Portal grabs objects
            if(hit.collider.tag == "PickUp")
            {
                isCarrying = !isCarrying;
                hit.collider.GetComponent<PickUp>().SetCarry(isCarrying);
            }
            // interact with button triggers an event
            else if(hit.collider.tag == "Button")
            {
                hit.collider.GetComponent<ButtonDetect>().ButtonPressed();
            }
        }
    }
}
