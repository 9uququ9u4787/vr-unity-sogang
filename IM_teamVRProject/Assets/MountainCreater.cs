using UnityEngine;

public class MountainCreater : MonoBehaviour
{
    // Ȱ��ȭ�� ���� ������Ʈ���� ������ �迭
    public GameObject[] mountains;

    // ��� ������Ʈ�� Ȱ��ȭ�ϴ� �Լ�
    public void ActivateObjects()
    {
        foreach (GameObject mountain in mountains)
        {
            if (mountain != null)
            {
                mountain.SetActive(true); // ������Ʈ Ȱ��ȭ
            }
        }
    }
}
