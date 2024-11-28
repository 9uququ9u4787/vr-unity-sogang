using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // 팝업 Panel GameObject

    // 팝업을 끄는 함수
    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    // 팝업을 켜는 함수 (필요한 경우)
    public void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
    }
}
