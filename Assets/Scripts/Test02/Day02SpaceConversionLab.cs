using UnityEngine;

/// <summary>
/// '위치'와 '방향'이 서로 다른 변환 규칙을 사용한다는 점을 확인합니다.
/// 기본 실습 값: Position(5,0,2), Rotation Y=90, Scale(1,1,1).
/// </summary>
public class Day02SpaceConversionLab : MonoBehaviour
{
    [ContextMenu("02 로컬과 월드 변환 확인")]
    private void PrintConvertedValues()
    {
        // 이 오브젝트를 기준으로 앞쪽 2만큼 떨어진 '위치'입니다.
        Vector3 localPoint = new Vector3(0f, 0f, 2f);

        // 로컬 위치를 월드 위치로 바꿉니다(위치·회전·크기를 반영).
        Vector3 worldPoint = transform.TransformPoint(localPoint);

        // 로컬 앞쪽 '방향'을 월드 방향으로 바꿉니다(회전만 반영).
        Vector3 worldDirection = transform.TransformDirection(Vector3.forward);

        // 두 변환을 다시 역으로 계산해 원래 로컬값을 확인합니다.
        Vector3 recoveredPoint = transform.InverseTransformPoint(worldPoint);
        Vector3 recoveredDirection = transform.InverseTransformDirection(worldDirection);

        Debug.Log("월드 위치: " + worldPoint.ToString("F2"));
        Debug.Log("월드 방향: " + worldDirection.ToString("F2"));
        Debug.Log("복원된 로컬 위치: " + recoveredPoint.ToString("F2"));
        Debug.Log("복원된 로컬 방향: " + recoveredDirection.ToString("F2"));
    }
}
