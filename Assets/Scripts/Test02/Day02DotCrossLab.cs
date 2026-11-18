using UnityEngine;

/// <summary>
/// 내적으로 앞뒤 방향을 판단하고, 외적으로 수직 방향을 계산합니다.
/// </summary>
public class Day02DotCrossLab : MonoBehaviour
{
    [SerializeField] private Transform target;

    [ContextMenu("03 내적과 외적 확인")]
    private void PrintDotAndCross()
    {
        if (target == null)
        {
            Debug.LogWarning("Target 슬롯을 먼저 연결하세요.");
            return;
        }

        // 목표 방향을 만들고 길이를 1로 정규화합니다.
        Vector3 toTarget = target.position - transform.position;
        if (toTarget.sqrMagnitude < 0.00000001f)
        {
            Debug.LogWarning("같은 위치에서는 목표 방향을 구할 수 없습니다.");
            return;
        }

        Vector3 targetDirection = toTarget.normalized;

        // transform.forward는 이 물체의 로컬 +Z가 향하는 월드 방향입니다.
        float dotValue = Vector3.Dot(transform.forward, targetDirection);

        // 두 방향에 수직인 벡터를 만듭니다.
        Vector3 crossValue = Vector3.Cross(Vector3.right, Vector3.up);

        Debug.Log("내적(앞=양수, 뒤=음수): " + dotValue.ToString("F2"));
        Debug.Log("외적(오른쪽 × 위): " + crossValue.ToString("F2"));
    }
}
