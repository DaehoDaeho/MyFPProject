using UnityEngine;

public class Day03FpsLook : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;
    [SerializeField, Min(0.01f)] private float lookSensitivity = 2.0f;
    [SerializeField] private float pitchLimit = 80.0f;

    private float yaw;
    private float pitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = 0.0f;
        cameraPivot.localRotation = Quaternion.identity;
        // 커서 잠금.
        LockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            // 커서 잠금 해제.
            ReleaseCursor();
        }

        if(Input.GetMouseButtonDown(0) == true && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * lookSensitivity;
        pitch -= mouseY * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -pitchLimit, pitchLimit);

        transform.rotation = Quaternion.Euler(0.0f, yaw, 0.0f);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
    }
}
