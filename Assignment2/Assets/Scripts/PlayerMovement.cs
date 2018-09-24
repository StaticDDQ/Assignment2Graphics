using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float Speed = 5f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    private CharacterController controller;
    private Vector3 velocity;
    private bool _isGrounded = true;
    private Transform Cam;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cam = transform.GetChild(0);
    }

    void Update()
    {

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        moveDir = Cam.TransformDirection(moveDir);
        controller.Move(moveDir * Time.deltaTime * Speed);

        velocity.y += Gravity * Time.deltaTime;

        _isGrounded = Physics.CheckSphere(Cam.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && velocity.y < 0)
            velocity.y = 0f;

        controller.Move(velocity * Time.deltaTime);
    }
}
