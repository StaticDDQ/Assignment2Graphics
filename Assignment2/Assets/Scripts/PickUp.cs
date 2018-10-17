using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] private float dist;
    [SerializeField] private float smooth;

	private bool isCarried = false;
    private Transform mainCam;
    private Rigidbody body;

    private void Start()
    {
        mainCam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
    }

    public void SetCarry(bool isCarrying)
    {
        isCarried = isCarrying;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCarried && (other.tag == "Floor" || other.tag == "Wall" || other.tag == "Player"))
        {
            SetCarry(false);
        }
    }

    // Update is called once per frame
    private void Update () {

		if (isCarried) {
            transform.position = Vector3.Lerp(transform.position, mainCam.position + mainCam.forward * dist, Time.deltaTime * smooth);
            
        }	
	}
}
