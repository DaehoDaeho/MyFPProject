using UnityEngine;

public class FPSPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private CharacterController controller;

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

        Vector3 displacement = worldDirection * moveSpeed * Time.deltaTime;

        controller.Move(displacement);
    }
}
