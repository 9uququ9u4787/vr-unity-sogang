using UnityEngine;

public class MountainCreater : MonoBehaviour
{
    // 활성화할 게임 오브젝트들을 저장할 배열
    public GameObject[] mountains;

    // 모든 오브젝트를 활성화하는 함수
    public void ActivateObjects()
    {
        foreach (GameObject mountain in mountains)
        {
            if (mountain != null)
            {
                mountain.SetActive(true); // 오브젝트 활성화
            }
        }
    }
}
