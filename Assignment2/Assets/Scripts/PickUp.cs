using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] private float dist;
    [SerializeField] private float smooth;
    [SerializeField] private float forcePush = 10f;

    private bool playerTouched = false;
    private bool isGrounded = true;
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
        if (!playerTouched)
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
                float force = mainCam.parent.GetComponent<PlayerMovement>().moveDir.magnitude;
                GetComponent<Rigidbody>().AddForce(mainCam.forward * force * forcePush,ForceMode.Impulse); 
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (!isGrounded && other.gameObject.tag == "Floor")
        {
            GetComponent<AudioSource>().Play();
            isGrounded = true;
        }

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.up, out hit, 2f) && hit.collider.tag == "Player")
        {
            playerTouched = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
        if(other.gameObject.tag == "Player")
        {
            playerTouched = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCarried && (other.tag == "Floor" || other.tag == "Wall"))
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
