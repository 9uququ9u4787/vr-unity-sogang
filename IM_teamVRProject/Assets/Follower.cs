using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator; // PathCreator ������Ʈ ����
    public float speed = 5; // �ʱ� �̵� �ӵ�
    public float break_percent = 0.8f; // ���߱� ������ ���� (0~1 ����)
    private float distanceTravelled; // �̵��� �Ÿ�
    private float initialSpeed; // �ʱ� �ӵ� ����
    private bool isMoving = false; // �̵� ����
    private bool isSlowingDown = false; // ���� ����

    void Start()
    {
        initialSpeed = speed; // �ʱ� �ӵ� ����
        //StartMoving();
    }

    void Update()
    {
        // �̵� ���� �ƴϸ� ����
        if (!isMoving) return;

        // �̵� �Ÿ� ������Ʈ
        distanceTravelled += speed * Time.deltaTime;

        // ����� ����
        float pathLength = pathCreator.path.length;

        // break_percent �������� ���� ����
        if (!isSlowingDown && distanceTravelled >= pathLength * break_percent)
        {
            isSlowingDown = true; // ���� ����
        }

        // ���� ����
        if (isSlowingDown)
        {
            // �ӵ��� ���������� ����
            float remainingDistance = pathLength - distanceTravelled; // ������ ���� �Ÿ�
            speed = Mathf.Lerp(0, initialSpeed, remainingDistance / (pathLength * (1 - break_percent)));

            // �ӵ��� 0�� ��������� ����
            if (remainingDistance <= 0.1f)
            {
                speed = 0; // �ӵ� ������ ����
                isMoving = false; // �̵� �ߴ�
                Debug.Log("Stopped naturally at the end of the path.");
                return;
            }
        }

        // ������Ʈ ��ġ �� ȸ�� ������Ʈ
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

    // �̵��� �����ϴ� �Լ�
    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            distanceTravelled = 0; // �̵� �ʱ�ȭ
            speed = initialSpeed; // �ӵ� �ʱ�ȭ
            isSlowingDown = false; // ���� ���� �ʱ�ȭ
            Debug.Log("Movement started!");
        }
    }
}
