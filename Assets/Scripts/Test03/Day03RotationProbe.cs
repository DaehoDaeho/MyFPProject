using UnityEngine;

/// <summary>
/// Unity의 Quaternion.Euler를 이용해 Y축 회전 결과를 확인합니다.
/// 2회차에서 학습한 transform.forward가 회전에 따라 달라지는지도 검사합니다.
/// </summary>
public class Day03RotationProbe : MonoBehaviour
{
    [ContextMenu("01 월드 Y축 90도 회전")]
    private void SetYaw90()
    {
        // 오일러 각 (X=0, Y=90, Z=0)을 Quaternion으로 변환합니다.
        Quaternion turnRight = Quaternion.Euler(0f, 90f, 0f);

        // 이 오브젝트의 월드 회전을 변경합니다.
        transform.rotation = turnRight;

        // 로컬 +Z축이 월드에서 어느 쪽을 향하는지 출력합니다.
        Debug.Log("회전 후 앞 방향: " + transform.forward.ToString("F2"), this);
        Debug.Log("Rotation 값: " + transform.rotation);
    }

    [ContextMenu("02 회전 초기화")]
    private void ResetRotation()
    {
        // 아무 회전도 적용하지 않은 기본 회전 상태입니다.
        transform.rotation = Quaternion.identity;
        Debug.Log("초기화 후 앞 방향: " + transform.forward.ToString("F2"), this);
        Debug.Log("Rotation 값: " + transform.rotation);
    }

    [ContextMenu("03 월드 Y축 180도 회전")]
    private void SetYaw180()
    {
        // 오일러 각 (X=0, Y=90, Z=0)을 Quaternion으로 변환합니다.
        Quaternion turnRight = Quaternion.Euler(0f, 180f, 0f);

        // 이 오브젝트의 월드 회전을 변경합니다.
        transform.rotation = turnRight;

        // 로컬 +Z축이 월드에서 어느 쪽을 향하는지 출력합니다.
        Debug.Log("회전 후 앞 방향: " + transform.forward.ToString("F2"), this);
        Debug.Log("Rotation 값: " + transform.rotation);
    }
}
