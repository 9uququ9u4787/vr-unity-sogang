using UnityEngine;

public class CenterController : MonoBehaviour
{
    // 4개의 오브젝트를 받을 배열
    public GameObject[] objects = new GameObject[4];

    // 모든 오브젝트가 도착했는지 나타내는 상태
    private bool all_on = false;

    // 활성화할 단일 오브젝트
    public GameObject targetObject;

    void Update()
    {
        CheckAllObjectsArrived();

        // all_on이 true일 때만 targetObject를 활성화
        if (all_on && targetObject != null && !targetObject.activeSelf)
        {
            targetObject.SetActive(true);
            Debug.Log($"{targetObject.name} has been activated!");
        }
    }

    // 모든 오브젝트의 is_arrive 상태를 확인
    private void CheckAllObjectsArrived()
    {
        all_on = true; // 초기값을 true로 설정하고 하나라도 false이면 false로 바뀜

        foreach (GameObject obj in objects)
        {
            if (obj == null)
            {
                Debug.LogWarning("One or more objects are not assigned.");
                all_on = false; // 오브젝트가 null인 경우도 조건에 실패
                return;
            }

            // ObjectController 스크립트 가져오기
            ObjectController objectController = obj.GetComponent<ObjectController>();
            if (objectController != null)
            {
                if (!objectController.is_arrive)
                {
                    all_on = false; // 하나라도 is_arrive가 false이면 실패
                    return;
                }
            }
            else
            {
                Debug.LogWarning($"{obj.name} does not have an ObjectController script attached.");
                all_on = false; // ObjectController가 없으면 조건에 실패
                return;
            }
        }

        if (all_on)
        {
            Debug.Log("All objects are in place! all_on = true");
        }
        else
        {
            Debug.Log("Not all objects are in place. all_on = false");
        }
    }
}
