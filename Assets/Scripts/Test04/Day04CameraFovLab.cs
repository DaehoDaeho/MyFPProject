using UnityEngine;

/// <summary>
/// 키보드 1, 2, 3을 눌러 Perspective 카메라의 시야각을 바꿉니다.
/// 3회차의 Day03FpsLook은 변경하지 않고 그대로 사용합니다.
/// </summary>
[RequireComponent(typeof(Camera))]
public class Day04CameraFovLab : MonoBehaviour
{
    // 같은 GameObject에 붙어 있는 Camera를 보관합니다.
    private Camera cameraComponent;

    private void Awake()
    {
        // Camera가 없으면 RequireComponent가 자동으로 추가합니다.
        cameraComponent = GetComponent<Camera>();
    }

    private void Update()
    {
        // 숫자 1, 2, 3을 눌렀을 때 서로 다른 시야각을 적용합니다.
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetFov(40f);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetFov(60f);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetFov(90f);
    }

    private void SetFov(float degrees)
    {
        // FOV 비교 중에는 원근 투영을 사용합니다.
        cameraComponent.orthographic = false;

        // Field of View는 각도(도 단위)입니다.
        cameraComponent.fieldOfView = degrees;

        // 어떤 값이 실제로 적용되었는지 Console에서 확인합니다.
        Debug.Log("현재 FOV: " + degrees + "도", this);
    }
}
