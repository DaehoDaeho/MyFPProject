using UnityEngine;

/// <summary>
/// 3D 좌표를 직접 읽고 이동시키는 실습용 컴포넌트입니다.
/// Rigidbody가 없는 기본 Cube나 Capsule에 부착하세요.
/// </summary>
public class Day01PositionLab : MonoBehaviour
{
    [ContextMenu("01 예시 좌표로 이동")]
    private void MoveToExample()
    {
        // (X, Y, Z) 순서로 월드 위치를 지정합니다.
        transform.position = new Vector3(2f, 1f, 3f);
        Debug.Log("예시 월드 좌표: " + transform.position);
    }

    [ContextMenu("02 월드와 로컬 좌표 확인")]
    private void PrintCoordinates()
    {
        // 장면 원점을 기준으로 한 현재 위치입니다.
        Debug.Log("월드 좌표: " + transform.position);
        // 부모가 있다면 부모를 기준으로 한 상대 위치입니다.
        Debug.Log("로컬 좌표: " + transform.localPosition);
    }

    [ContextMenu("03 월드 X 방향으로 1 이동")]
    private void MoveWorldRight()
    {
        // Vector3.right는 월드 X의 양의 방향 (1,0,0)입니다.
        transform.position += Vector3.right;
        Debug.Log("X 이동 후 월드: " + transform.position);
    }

    [ContextMenu("04 로컬 Z 방향으로 1 이동")]
    private void MoveLocalForward()
    {
        // 부모를 기준으로 Z 위치값을 1 증가시킵니다.
        // 부모가 회전하면 월드에서 보이는 방향은 달라집니다.
        transform.localPosition += Vector3.forward;
        Debug.Log("Z 이동 후 로컬: " + transform.localPosition);
        Debug.Log("Z 이동 후 월드: " + transform.position);
    }

    [ContextMenu("05 월드 원점으로 이동")]
    private void ResetWorldPosition()
    {
        // 부모가 없는 단독 오브젝트에서 먼저 실행해 보세요.
        // 자식에서 실행하면 월드 원점에 맞춰 로컬값이 달라집니다.
        transform.position = Vector3.zero;
        Debug.Log("원점 이동 후 월드: " + transform.position);
    }
}
