using UnityEngine;

public class LifecycleTest : MonoBehaviour
{
    // 1. 게임 오브젝트가 생성될 때 가장 먼저 호출됩니다.
    // (컴포넌트가 꺼져(Disable) 있더라도, 게임 오브젝트가 켜져(Active) 있으면 호출됩니다.)
    private void Awake()
    {
        Debug.Log("[Lifecycle] Awake - 객체가 메모리에 로드될 때 딱 1번 호출");
    }

    // 2. 컴포넌트(스크립트)가 활성화(Enable)될 때마다 호출됩니다.
    private void OnEnable()
    {
        Debug.Log("[Lifecycle] OnEnable - 컴포넌트가 켜질 때마다 호출");
    }

    // 3. 첫 번째 프레임의 Update가 시작되기 바로 직전에 딱 1번 호출됩니다.
    // (보통 초기화 작업에 주로 쓰입니다.)
    private void Start()
    {
        Debug.Log("[Lifecycle] Start - 첫 번째 Update 프레임 직전에 딱 1번 호출");
    }

    // 4. 물리 연산(Physics)을 위해 일정한 시간 간격(기본 0.02초)마다 실행됩니다.
    // (컴퓨터 성능과 관계없이 균등한 시간 간격으로 실행되는 물리 루프입니다.)
    private void FixedUpdate()
    {
        Debug.Log("[Lifecycle] FixedUpdate - 물리 연산 주기마다 고정된 간격으로 호출");
    }

    // 5. 매 프레임마다 실행됩니다. 게임의 주 로직이 여기서 일어납니다.
    // (컴퓨터 성능(FPS)에 따라 호출 빈도가 달라집니다.)
    private void Update()
    {
        Debug.Log("[Lifecycle] Update - 매 프레임마다 호출 (화면 렌더링 주기)");
    }

    // 6. 모든 Update 함수가 다 실행된 후, 프레임이 끝날 때 마지막으로 호출됩니다.
    // (보통 캐릭터가 다 움직인 뒤 카메라가 캐릭터를 따라가는 로직 등에 쓰입니다.)
    private void LateUpdate()
    {
        Debug.Log("[Lifecycle] LateUpdate - 모든 Update 실행 직후 매 프레임 호출");
    }

    // 7. 컴포넌트(스크립트)가 비활성화(Disable)될 때마다 호출됩니다.
    private void OnDisable()
    {
        Debug.Log("[Lifecycle] OnDisable - 컴포넌트가 꺼질 때마다 호출");
    }

    // 8. 게임 오브젝트가 씬에서 소멸(Destroy)되거나 게임이 종료될 때 딱 1번 호출됩니다.
    private void OnDestroy()
    {
        Debug.Log("[Lifecycle] OnDestroy - 객체가 파괴되거나 게임 종료 시 딱 1번 호출");
    }
}
