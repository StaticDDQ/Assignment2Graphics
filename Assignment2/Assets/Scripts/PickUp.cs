using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] private float dist;

	private bool isCarried = false;

    private Rigidbody body;
    private Transform mainCam;

    private void Start()
    {
        mainCam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
    }

    public void SetCarry()
    {
        isCarried = !isCarried;
        body.useGravity = !isCarried;
        body.freezeRotation = isCarried;

        if (isCarried)
            transform.SetParent(mainCam);
        else
            transform.SetParent(null);
    }

	// Update is called once per frame
	private void Update () {

		if (isCarried) {
            transform.position = Vector3.Lerp(transform.position, mainCam.transform.position + mainCam.transform.forward * dist, Time.deltaTime);
            
        }	
	}
}
