using UnityEngine;

public class AngleActivation : MonoBehaviour
{
    public GameObject targetObject; // 활성화/비활성화할 대상 오브젝트
    public float angleThreshold; // '각도입계점' 변수

    void Update()
    {
        CheckAndToggleObjectState();
    }

    private void CheckAndToggleObjectState()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned!");
            return;
        }

        // 자신의 현재 회전 값 (음수 처리 포함)
        float xRotation = transform.eulerAngles.x;
        float zRotation = transform.eulerAngles.z;

        // 각도 조건 확인
        if ((xRotation > angleThreshold && xRotation < 360 - angleThreshold)|| (zRotation > angleThreshold && zRotation < 360 - angleThreshold))
        {
            // 각도가 기준을 초과하면 활성화
            if (!targetObject.activeSelf)
            {
                targetObject.SetActive(true); // 활성화
                Debug.Log($"Activated {targetObject.name}: x={xRotation}, z={zRotation}");
            }
        }
        else
        {
            // 각도가 기준 이하로 내려가면 비활성화
            if (targetObject.activeSelf)
            {
                targetObject.SetActive(false); // 비활성화
                Debug.Log($"Deactivated {targetObject.name}: x={xRotation}, z={zRotation}");
            }
        }
    }

    
}
