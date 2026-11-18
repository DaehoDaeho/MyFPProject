using UnityEngine;

/// <summary>
/// 현재 오브젝트에서 목표까지의 벡터를 계산하고 Scene 뷰에 표시합니다.
/// 1회차의 Transform 위치 학습을 '목표를 향한 방향'으로 확장하는 예제입니다.
/// </summary>
public class Day02TargetVectorLab : MonoBehaviour
{
    // Inspector에서 목표 오브젝트의 Transform을 연결합니다.
    [SerializeField] private Transform target;

    [ContextMenu("01 목표까지의 벡터 확인")]
    private void PrintTargetVector()
    {
        // 목표를 연결하지 않은 상태에서 실행하면 계산할 수 없습니다.
        if (target == null)
        {
            Debug.LogWarning("Target 슬롯에 목표 오브젝트를 연결하세요.");
            return;
        }

        // 도착 위치에서 출발 위치를 빼면 출발점에서 도착점까지의 벡터가 됩니다.
        Vector3 toTarget = target.position - transform.position;

        // magnitude는 벡터의 길이, 즉 목표까지의 거리를 뜻합니다.
        float distance = toTarget.magnitude;

        // normalized는 방향을 유지하면서 길이를 1로 만든 벡터입니다.
        // 두 위치가 같으면 Vector3.zero가 나오므로 별도로 확인합니다.
        Vector3 direction = toTarget.normalized;

        Debug.Log("목표까지의 벡터: " + toTarget.ToString("F2"));
        Debug.Log("목표까지의 거리: " + distance.ToString("F2"));
        Debug.Log("목표 방향(길이 1): " + direction.ToString("F2"));

        if (distance < 0.0001f)
        {
            Debug.LogWarning("출발점과 목표점이 같아서 방향을 정할 수 없습니다.");
        }
    }

    // Scene 뷰에서 이 오브젝트를 선택하면 목표 방향을 선으로 보여줍니다.
    private void OnDrawGizmosSelected()
    {
        if (target == null) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.DrawSphere(target.position, 0.15f);
    }
}
