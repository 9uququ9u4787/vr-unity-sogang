using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSocket : MonoBehaviour
{
    public GameObject assignedObject;

    public Boolean is_on = false;

    void Update()
    {
        // Update���� Arrive() ȣ��
        // �ʿ信 ���� ���� �߰� ����
        //Arrive();
    }

    public void Arrive()
    {
        if (assignedObject == null) return;

        // assignedObject�� ObjectController ��ũ��Ʈ�� �ִ��� Ȯ��
        var objectController = assignedObject.GetComponent<ObjectController>();
        if (objectController != null)
        {
            objectController.is_arrive = true; // ���� ���� ������Ʈ
            Debug.Log($"{assignedObject.name} has arrived in the socket. is_arrive: {objectController.is_arrive}");
        }
        else
        {
            Debug.LogWarning("Assigned object does not have an ObjectController script.");
        }

        // XRGrabInteractable ��Ȱ��ȭ
        var grabInteractable = assignedObject.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            
            //grabInteractable.enabled = false; // XR ��ȣ�ۿ� ��Ȱ��ȭ
            Debug.Log($"{assignedObject.name}'s XRGrabInteractable has been disabled.");
        }
        else
        {
            Debug.LogWarning("Assigned object does not have an XRGrabInteractable component.");
        }

        is_on=true;
    }
}
