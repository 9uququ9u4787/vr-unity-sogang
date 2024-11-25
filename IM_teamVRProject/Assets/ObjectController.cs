using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // 두 개의 오브젝트를 에디터에서 할당할 수 있도록 public으로 선언
    public GameObject element_in;
    public GameObject element_out;
    public GameObject element_hover;
    public GameObject firefly;
    public GameObject firefly_start;

    public bool is_arrive = false;
    private bool is_get = false;
    private Collider objCollider;

    // 시작 시 호출되는 메서드
    void Start()
    {
        // Collider를 가져옴
        objCollider = GetComponent<Collider>();
    }

    // 매 프레임마다 호출되는 메서드
    void Update()
    {
        // is_arrive가 true라면 콜라이더를 비활성화
        if (is_arrive)
        {
            SetArrive();
        }
    }

    public void OnCheckObject()
    {
        if (is_get == false)
        {
            element_hover.SetActive(true);
            element_in.SetActive(false);
            firefly.SetActive(false);
        }
    }

    public void OffCheckObject()
    {
        if (is_get == false)
        {
            element_hover.SetActive(false);
            element_in.SetActive(true);
            firefly.SetActive(false);
        }
    }

    public void GetObject()
    {
        is_get = true;
        firefly_start.SetActive(true);
        firefly.SetActive(true);
        element_hover.SetActive(false);
        element_in.SetActive(false);
    }

    // 콜라이더를 비활성화하는 함수
    private void SetArrive()
    {
        if (objCollider != null && objCollider.enabled)
        {
            //objCollider.enabled = false;
            //Debug.Log($"{gameObject.name}의 Collider가 비활성화되었습니다.");
            element_out.SetActive(true);
            firefly_start.SetActive(false);
            firefly.SetActive(false);
            element_hover.SetActive(false);
        }
    }
}
