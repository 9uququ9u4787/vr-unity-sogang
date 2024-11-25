using UnityEngine;

public class CenterController : MonoBehaviour
{
    // 4���� ������Ʈ�� ���� �迭
    public GameObject[] objects = new GameObject[4];

    // ��� ������Ʈ�� �����ߴ��� ��Ÿ���� ����
    private bool all_on = false;

    // Ȱ��ȭ�� ���� ������Ʈ
    public GameObject targetObject;

    void Update()
    {
        CheckAllObjectsArrived();

        // all_on�� true�� ���� targetObject�� Ȱ��ȭ
        if (all_on && targetObject != null && !targetObject.activeSelf)
        {
            targetObject.SetActive(true);
            Debug.Log($"{targetObject.name} has been activated!");
        }
    }

    // ��� ������Ʈ�� is_arrive ���¸� Ȯ��
    private void CheckAllObjectsArrived()
    {
        all_on = true; // �ʱⰪ�� true�� �����ϰ� �ϳ��� false�̸� false�� �ٲ�

        foreach (GameObject obj in objects)
        {
            if (obj == null)
            {
                Debug.LogWarning("One or more objects are not assigned.");
                all_on = false; // ������Ʈ�� null�� ��쵵 ���ǿ� ����
                return;
            }

            // ObjectController ��ũ��Ʈ ��������
            ObjectController objectController = obj.GetComponent<ObjectController>();
            if (objectController != null)
            {
                if (!objectController.is_arrive)
                {
                    all_on = false; // �ϳ��� is_arrive�� false�̸� ����
                    return;
                }
            }
            else
            {
                Debug.LogWarning($"{obj.name} does not have an ObjectController script attached.");
                all_on = false; // ObjectController�� ������ ���ǿ� ����
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
