using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f; // 점프력 (Inspector에서 조절 가능)

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트 참조 (수정!)

    void Start()
    {
        // 오브젝트에 Rigidbody2D 컴포넌트가 있는지 확인하고 가져옴
        rb = GetComponent<Rigidbody2D>(); // 수정!
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D 컴포넌트가 없습니다. 점프 기능을 사용할 수 없습니다."); // 메시지 수정!
            enabled = false; // 스크립트 비활성화
        }
    }

    void Update()
    {
        // 스페이스바를 누르면 무조건 점프
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Rigidbody2D에 위쪽 방향으로 힘을 가함
        // Vector2.up은 (0, 1) 방향을 나타냄
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // 수정!
    }
}