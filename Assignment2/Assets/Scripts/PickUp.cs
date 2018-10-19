using UnityEngine;

public class PickUp : MonoBehaviour {

	[SerializeField] private float dist = 2f;
    [SerializeField] private float smooth = 6f;
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

    // removing rotation and parent the object to the camera when carrying to allow smooth movement
    // otherwise if the player drop the object will moving, it will apply a push force based on the movement speed
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

    // play audio if the object lands on the floor, otherwise prevent the player to pick the object up if player is directly on top of this object
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

    // player can now pick up the object, or the object is currently on the air
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

    // drop the object if it touches the floor or wall
    private void OnTriggerEnter(Collider other)
    {
        if (isCarried && (other.tag == "Floor" || other.tag == "Wall"))
        {
            SetCarry(false);
        }
    }

    // Update is called once per frame
    // have object always be in front of the camera when being carried
    private void Update () {
		if (isCarried) {
            transform.position = Vector3.Lerp(transform.position, mainCam.position + mainCam.forward * dist, Time.deltaTime * smooth);   
        }
    }
}
