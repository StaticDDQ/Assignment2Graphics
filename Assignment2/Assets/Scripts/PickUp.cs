using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] private float dist;
    [SerializeField] private float smooth;
    [SerializeField] private float moveDown;

	private bool isCarried = false;
    private Transform mainCam;
    private Rigidbody body;

    private void Start()
    {
        mainCam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
    }

    public void SetCarry()
    {
        isCarried = !isCarried;
        body.isKinematic = isCarried;
        body.freezeRotation = isCarried;
        

        if (isCarried)
        {
            transform.SetParent(mainCam);
        }
        else
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCarried && (other.tag == "Floor" || other.tag == "Wall"))
        {
            SetCarry();
        }
    }

    // Update is called once per frame
    private void Update () {

		if (isCarried) {
            transform.position = Vector3.Lerp(transform.position, mainCam.position + mainCam.forward * dist - mainCam.up* moveDown, Time.deltaTime * smooth);
            
        }	
	}
}
