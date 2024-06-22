using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiObject; // 나타낼 UI 요소
    public float displayTime = 3f; // UI를 표시할 시간

    private void Start() {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 콜라이더와 충돌했을 때
        {
            StartCoroutine(DisplayUI()); // UI를 표시하는 코루틴 시작
        }
    }

    IEnumerator DisplayUI()
    {
        uiObject.SetActive(true); // UI 활성화
        yield return new WaitForSeconds(displayTime); // 일정 시간 대기
        uiObject.SetActive(false); // UI 비활성화
    }
}
