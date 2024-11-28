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
        
        // 이벤트 구독
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        // 이벤트 구독 해제
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    // 오브젝트를 잡을 때 호출
    private void OnGrab(SelectEnterEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = true; // 잡을 때는 kinematic 활성화
        }
    }

    // 오브젝트를 놓을 때 호출
    private void OnRelease(SelectExitEventArgs args)
    {
        if (rb != null)
        {
            rb.isKinematic = false; // 놓을 때는 kinematic 비활성화
        }
    }
}
