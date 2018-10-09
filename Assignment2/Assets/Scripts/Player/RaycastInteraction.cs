using UnityEngine;

public class RaycastInteraction : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField] private float distanceToSee = 3;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            if(hit.collider.tag == "PickUp")
            {
                hit.collider.GetComponent<PickUp>().SetCarry();
            }
            else if(hit.collider.tag == "Button")
            {
                hit.collider.GetComponent<ButtonDetect>().ButtonPressed();
            }
        }
    }
}
