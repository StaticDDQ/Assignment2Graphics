using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private new Rigidbody rigidbody;
    private Transform cam;

    public float gravity = 9.81f;
    public float moveSpeed = 3f;
    public float jumpHeight = 5f;
    public float height = 2f;

    private Vector3 moveDir = Vector3.zero;
    private float distToGround;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir = cam.TransformDirection(moveDir);
        moveDir.y = 0f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rigidbody.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
        }

        rigidbody.MovePosition(transform.position + Vector3.Normalize(moveDir) * Time.deltaTime * moveSpeed);
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
