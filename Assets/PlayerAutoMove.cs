using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    // 이동 속도 (Inspector에서 조절 가능)
    public float moveSpeed = 5f;

    // Rigidbody2D 컴포넌트 참조
    private Rigidbody2D rb;

    void Start()
    {
        // 오브젝트에 Rigidbody2D 컴포넌트가 있는지 확인하고 가져옴
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("PlayerAutoMove: Rigidbody2D 컴포넌트가 없습니다. 자동 이동 기능을 사용할 수 없습니다.");
            enabled = false; // 스크립트 비활성화
        }
    }

    // FixedUpdate는 물리 연산 업데이트에 적합합니다.
    void FixedUpdate()
    {
        // Rigidbody2D의 x축 선형 속도를 moveSpeed로 설정하여 우측으로 이동
        // y축 속도(중력이나 점프 등으로 인한 수직 속도)는 현재 값을 유지합니다.
        // Vector2.right는 (1, 0) 방향을 나타냅니다.

        // 경고를 해결하기 위해 'rb.velocity'를 'rb.linearVelocity'로 변경합니다.
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y); // <-- 이 부분을 수정했습니다.
    }
}