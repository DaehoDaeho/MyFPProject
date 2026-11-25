using UnityEngine;

public class FPSPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.5f;

    private CharacterController controller;
    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 localDirection = new Vector3(horizontal, 0.0f, vertical);
        localDirection = localDirection.normalized;

        Vector3 worldDirection = transform.TransformDirection(localDirection);

        bool grounded = controller.isGrounded;
        if(grounded == true && verticalVelocity < 0.0f)
        {
            verticalVelocity = -2.0f;
        }

        if(grounded == true && Input.GetKeyDown(KeyCode.Space) == true)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 displacement = ((worldDirection * moveSpeed) + (Vector3.up * verticalVelocity)) * Time.deltaTime;

        controller.Move(displacement);
    }
}
