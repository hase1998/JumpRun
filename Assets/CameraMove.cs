using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // 카메라가 따라갈 대상 (플레이어 오브젝트)
    public Transform target;

    // 카메라와 대상 간의 오프셋 (거리 차이)
    // 인스펙터에서 조절해서 카메라 위치를 세밀하게 조정할 수 있어요.
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    // 카메라 이동 속도 (카메라가 대상을 따라가는 부드러움 정도)
    public float smoothSpeed = 0.125f;

    // 카메라의 Y축 위치를 고정할지 여부
    public bool lockYPosition = true;

    // Y축을 고정할 경우, 이 값을 사용합니다.
    public float fixedYPosition = 0f; // 인스펙터에서 적절한 카메라 Y 위치로 설정

    void LateUpdate()
    {
        // LateUpdate는 모든 Update 함수가 호출된 후 마지막에 호출돼요.
        // 캐릭터의 이동이 완전히 끝난 후에 카메라를 움직여서 부드러움을 보장합니다.

        if (target == null)
        {
            Debug.LogWarning("CameraMove: Target 오브젝트가 설정되지 않았습니다.");
            return;
        }

        // 카메라가 목표로 할 위치를 계산합니다.
        Vector3 desiredPosition = target.position + offset;

        // Y축 고정 옵션이 활성화되어 있다면 Y값만 고정합니다.
        if (lockYPosition)
        {
            desiredPosition.y = fixedYPosition;
        }

        // 현재 카메라 위치에서 목표 위치까지 부드럽게 이동합니다.
        // Lerp는 두 위치 사이를 부드럽게 보간(Interpolate)합니다.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}