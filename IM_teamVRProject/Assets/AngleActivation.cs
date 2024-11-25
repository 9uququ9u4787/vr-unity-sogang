using UnityEngine;

public class AngleActivation : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ/��Ȱ��ȭ�� ��� ������Ʈ
    public float angleThreshold; // '�����԰���' ����

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

        // �ڽ��� ���� ȸ�� �� (���� ó�� ����)
        float xRotation = transform.eulerAngles.x;
        float zRotation = transform.eulerAngles.z;

        // ���� ���� Ȯ��
        if ((xRotation > angleThreshold && xRotation < 360 - angleThreshold)|| (zRotation > angleThreshold && zRotation < 360 - angleThreshold))
        {
            // ������ ������ �ʰ��ϸ� Ȱ��ȭ
            if (!targetObject.activeSelf)
            {
                targetObject.SetActive(true); // Ȱ��ȭ
                Debug.Log($"Activated {targetObject.name}: x={xRotation}, z={zRotation}");
            }
        }
        else
        {
            // ������ ���� ���Ϸ� �������� ��Ȱ��ȭ
            if (targetObject.activeSelf)
            {
                targetObject.SetActive(false); // ��Ȱ��ȭ
                Debug.Log($"Deactivated {targetObject.name}: x={xRotation}, z={zRotation}");
            }
        }
    }

    
}
