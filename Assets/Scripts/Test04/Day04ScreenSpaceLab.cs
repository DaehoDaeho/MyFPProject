using UnityEngine;

/// <summary>
/// 목표의 월드 위치를 픽셀 좌표와 Viewport 좌표로 변환합니다.
/// 또한 화면 중앙을 통과하는 월드 공간의 Ray를 Scene 뷰에 표시합니다.
/// </summary>
[RequireComponent(typeof(Camera))]
public class Day04ScreenSpaceLab : MonoBehaviour
{
    // 좌표를 검사할 목표 오브젝트입니다.
    [SerializeField] private Transform target;

    // Scene 뷰에서 보일 디버그 Ray의 길이입니다.
    [SerializeField, Min(0.1f)] private float rayLength = 12f;

    // 이 스크립트가 붙은 Main Camera의 Camera 컴포넌트입니다.
    private Camera cameraComponent;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();

        // 목표 연결을 빠뜨렸다면 실행하지 않고 원인을 알려줍니다.
        if (target == null)
        {
            Debug.LogError("Inspector에서 Target을 연결하세요.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        // Viewport (0.5, 0.5)는 화면의 정중앙입니다.
        // Ray는 카메라의 Near Plane에서 시작합니다.
        Ray centerRay = cameraComponent.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f));

        // Scene 뷰에서 카메라의 중앙 방향을 선으로 확인합니다.
        Debug.DrawRay(centerRay.origin,
            centerRay.direction * rayLength, Color.cyan);

        // G를 누른 순간에만 좌표를 출력해 Console이 과도하게 쌓이지 않게 합니다.
        if (Input.GetKeyDown(KeyCode.G))
        {
            PrintCoordinates();
        }
    }

    private void PrintCoordinates()
    {
        // 3D 공간 안에서 목표가 놓인 실제 위치입니다.
        Vector3 world = target.position;

        // 월드 위치를 Game 화면의 픽셀 좌표로 변환합니다.
        Vector3 screen = cameraComponent.WorldToScreenPoint(world);

        // 월드 위치를 0~1 범위의 화면 비율 좌표로 변환합니다.
        Vector3 viewport = cameraComponent.WorldToViewportPoint(world);

        Debug.Log("월드 위치: " + world.ToString("F2"), this);
        Debug.Log("화면 픽셀 좌표: " + screen.ToString("F2"), this);
        Debug.Log("Viewport 좌표: " + viewport.ToString("F2"), this);

        // z는 카메라 앞뒤를 판별하는 데 필요합니다.
        Debug.Log("카메라 앞쪽 여부: " + (viewport.z > 0f), this);
    }
}
