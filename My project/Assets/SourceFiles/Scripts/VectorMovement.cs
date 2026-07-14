using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [Tooltip("초당 이동할 속도 (미터/초)")]
    public float moveSpeed = 5f;

    [Header("부드러운 이동 (Lerp) 설정")]
    [Tooltip("체크하면 Lerp 모드로 작동합니다. (목표 지점으로 이동)")]
    public bool useLerpMovement = false;
    
    [Tooltip("Lerp 모드일 때 이동할 목표 지점")]
    public Vector3 targetPosition = new Vector3(5f, 0.5f, 5f);
    
    [Range(0f, 1f)]
    [Tooltip("Lerp의 속도 조절 인자 (매 프레임마다 남은 거리의 몇 %만큼 갈지 결정)")]
    public float lerpFactor = 0.05f;

    private void Update()
    {
        if (!useLerpMovement)
        {
            // 1. 키보드 입력을 통한 기본 등속 이동 모드
            HandleKeyboardMovement();
        }
        else
        {
            // 2. Vector3.Lerp를 이용한 목표 지점 부드러운 추적 모드
            HandleLerpMovement();
        }
    }

    /// <summary>
    /// 키보드 방향키(또는 WASD)를 통해 등속 이동을 처리합니다.
    /// </summary>
    private void HandleKeyboardMovement()
    {
        // GetAxisRaw는 -1, 0, 1 중 하나의 값을 즉시 반환합니다. (방향키/WASD 입력)
        float h = Input.GetAxisRaw("Horizontal"); // A, D 또는 Left, Right
        float v = Input.GetAxisRaw("Vertical");   // W, S 또는 Up, Down

        // 입력받은 값을 바탕으로 3차원 방향 벡터(Direction Vector) 생성
        Vector3 direction = new Vector3(h, 0f, v);

        // 대각선 이동 시 속도가 빨라지는 것을 방지하기 위해 정규화(Normalize)
        // (정규화를 하면 벡터의 길이를 1로 만들어 방향 정보만 남깁니다.)
        if (direction.magnitude > 0.1f)
        {
            direction = direction.normalized;
        }

        // 이동 공식: 이동 = 방향 * 속도 * 시간 간격
        // **[중요] Time.deltaTime**:
        // - 이전 프레임에서 현재 프레임까지 걸린 시간(초)을 곱해줍니다.
        // - 60 FPS 컴퓨터와 120 FPS 컴퓨터에서 똑같이 1초에 moveSpeed만큼 움직이도록 만들어줍니다. (프레임 독립성)
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // 실제 오브젝트의 위치(Position)를 이동시킵니다.
        transform.Translate(movement);
    }

    /// <summary>
    /// Vector3.Lerp를 이용해 현재 위치에서 목표 위치로 부드럽게 이동합니다.
    /// </summary>
    private void HandleLerpMovement()
    {
        // Vector3.Lerp(시작위치, 목표위치, 비율(0~1))
        // 매 프레임마다 현재 위치(A)에서 목표 위치(B)로 lerpFactor만큼 비율로 이동합니다.
        // 목표에 가까워질수록 이동 거리가 줄어들기 때문에 감속하면서 부드럽게 안착하는 효과가 납니다.
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpFactor);

        // 콘솔에 목표 위치와의 거리를 모니터링하기 위해 출력 (어느 정도 도달했는지 확인용)
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.05f)
        {
            Debug.Log($"[Lerp] 목표까지 남은 거리: {distance:F2}m");
        }
    }
}
