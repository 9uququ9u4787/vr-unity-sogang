using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator; // PathCreator 컴포넌트 참조
    public float speed = 5; // 초기 이동 속도
    public float break_percent = 0.8f; // 멈추기 시작할 지점 (0~1 범위)
    private float distanceTravelled; // 이동한 거리
    private float initialSpeed; // 초기 속도 저장
    private bool isMoving = false; // 이동 상태
    private bool isSlowingDown = false; // 감속 상태

    void Start()
    {
        initialSpeed = speed; // 초기 속도 저장
        //StartMoving();
    }

    void Update()
    {
        // 이동 중이 아니면 리턴
        if (!isMoving) return;

        // 이동 거리 업데이트
        distanceTravelled += speed * Time.deltaTime;

        // 경로의 길이
        float pathLength = pathCreator.path.length;

        // break_percent 지점에서 감속 시작
        if (!isSlowingDown && distanceTravelled >= pathLength * break_percent)
        {
            isSlowingDown = true; // 감속 시작
        }

        // 감속 로직
        if (isSlowingDown)
        {
            // 속도를 점진적으로 줄임
            float remainingDistance = pathLength - distanceTravelled; // 끝까지 남은 거리
            speed = Mathf.Lerp(0, initialSpeed, remainingDistance / (pathLength * (1 - break_percent)));

            // 속도가 0에 가까워지면 멈춤
            if (remainingDistance <= 0.1f)
            {
                speed = 0; // 속도 완전히 멈춤
                isMoving = false; // 이동 중단
                Debug.Log("Stopped naturally at the end of the path.");
                return;
            }
        }

        // 오브젝트 위치 및 회전 업데이트
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

    // 이동을 시작하는 함수
    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            distanceTravelled = 0; // 이동 초기화
            speed = initialSpeed; // 속도 초기화
            isSlowingDown = false; // 감속 상태 초기화
            Debug.Log("Movement started!");
        }
    }
}
