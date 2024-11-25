using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // �� ���� ������Ʈ�� �����Ϳ��� �Ҵ��� �� �ֵ��� public���� ����
    public GameObject element_in;
    public GameObject element_out;
    public GameObject element_hover;
    public GameObject firefly;
    public GameObject firefly_start;

    public bool is_arrive = false;
    private bool is_get = false;
    private Collider objCollider;

    // ���� �� ȣ��Ǵ� �޼���
    void Start()
    {
        // Collider�� ������
        objCollider = GetComponent<Collider>();
    }

    // �� �����Ӹ��� ȣ��Ǵ� �޼���
    void Update()
    {
        // is_arrive�� true��� �ݶ��̴��� ��Ȱ��ȭ
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

    // �ݶ��̴��� ��Ȱ��ȭ�ϴ� �Լ�
    private void SetArrive()
    {
        if (objCollider != null && objCollider.enabled)
        {
            //objCollider.enabled = false;
            //Debug.Log($"{gameObject.name}�� Collider�� ��Ȱ��ȭ�Ǿ����ϴ�.");
            element_out.SetActive(true);
            firefly_start.SetActive(false);
            firefly.SetActive(false);
            element_hover.SetActive(false);
        }
    }
}
