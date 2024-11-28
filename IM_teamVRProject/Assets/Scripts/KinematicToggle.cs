using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KinematicToggle : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        
        // �̺�Ʈ ����
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        // �̺�Ʈ ���� ����
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    // ������Ʈ�� ���� �� ȣ��
    private void OnGrab(SelectEnterEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = true; // ���� ���� kinematic Ȱ��ȭ
        }
    }

    // ������Ʈ�� ���� �� ȣ��
    private void OnRelease(SelectExitEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = false; // ���� ���� kinematic ��Ȱ��ȭ
        }
    }
}
