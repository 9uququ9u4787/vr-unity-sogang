using UnityEngine;

public class SnapOnCollision : MonoBehaviour
{
    public GameObject targetObject; // 충돌할 오브젝트를 유니티 에디터에서 할당

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 스크립트에 할당된 targetObject인지 확인
        if (collision.gameObject == targetObject)
        {
            // plate1의 중심으로 이동시키기
            SnapObjectToCenter(collision.gameObject);
        }
    }

    // 오브젝트를 plate1의 중심에 고정하고 ObjectController의 is_arrive를 true로 설정
    private void SnapObjectToCenter(GameObject obj)
    {
        // plate1의 위치와 회전에 맞춰 오브젝트 고정
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        // 오브젝트의 Rigidbody가 있다면, 물리적 움직임을 멈춤
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // 물리 시뮬레이션 중지
        }

        // ObjectController 스크립트에서 is_arrive 변수를 true로 설정
        ObjectController controller = obj.GetComponent<ObjectController>();
        if (controller != null)
        {
            controller.is_arrive = true;
            Debug.Log($"{obj.name}의 is_arrive가 true로 설정되었습니다.");
        }
        else
        {
            Debug.LogWarning($"{obj.name}에 ObjectController 스크립트가 없습니다.");
        }

        Debug.Log($"{obj.name}이(가) plate1의 중심에 고정되었습니다.");
    }
}
