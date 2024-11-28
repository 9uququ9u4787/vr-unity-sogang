using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSocket : MonoBehaviour
{
    public GameObject assignedObject;

    public Boolean is_on = false;

    void Update()
    {
        // Update에서 Arrive() 호출
        // 필요에 따라 조건 추가 가능
        //Arrive();
    }

    public void Arrive()
    {
        if (assignedObject == null) return;

        // assignedObject에 ObjectController 스크립트가 있는지 확인
        var objectController = assignedObject.GetComponent<ObjectController>();
        if (objectController != null)
        {
            objectController.is_arrive = true; // 소켓 상태 업데이트
            Debug.Log($"{assignedObject.name} has arrived in the socket. is_arrive: {objectController.is_arrive}");
        }
        else
        {
            Debug.LogWarning("Assigned object does not have an ObjectController script.");
        }

        // XRGrabInteractable 비활성화
        var grabInteractable = assignedObject.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            
            //grabInteractable.enabled = false; // XR 상호작용 비활성화
            Debug.Log($"{assignedObject.name}'s XRGrabInteractable has been disabled.");
        }
        else
        {
            Debug.LogWarning("Assigned object does not have an XRGrabInteractable component.");
        }

        is_on=true;
    }
}
