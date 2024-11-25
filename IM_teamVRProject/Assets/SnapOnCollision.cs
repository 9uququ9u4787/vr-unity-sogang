using UnityEngine;

public class SnapOnCollision : MonoBehaviour
{
    public GameObject targetObject; // �浹�� ������Ʈ�� ����Ƽ �����Ϳ��� �Ҵ�

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ��ũ��Ʈ�� �Ҵ�� targetObject���� Ȯ��
        if (collision.gameObject == targetObject)
        {
            // plate1�� �߽����� �̵���Ű��
            SnapObjectToCenter(collision.gameObject);
        }
    }

    // ������Ʈ�� plate1�� �߽ɿ� �����ϰ� ObjectController�� is_arrive�� true�� ����
    private void SnapObjectToCenter(GameObject obj)
    {
        // plate1�� ��ġ�� ȸ���� ���� ������Ʈ ����
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        // ������Ʈ�� Rigidbody�� �ִٸ�, ������ �������� ����
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // ���� �ùķ��̼� ����
        }

        // ObjectController ��ũ��Ʈ���� is_arrive ������ true�� ����
        ObjectController controller = obj.GetComponent<ObjectController>();
        if (controller != null)
        {
            controller.is_arrive = true;
            Debug.Log($"{obj.name}�� is_arrive�� true�� �����Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogWarning($"{obj.name}�� ObjectController ��ũ��Ʈ�� �����ϴ�.");
        }

        Debug.Log($"{obj.name}��(��) plate1�� �߽ɿ� �����Ǿ����ϴ�.");
    }
}
