using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ATMInteract : MonoBehaviour
{
    public GameObject interactionUI; // 상호작용 UI
    public Slider interactionSlider; // 상호작용 슬라이더
    private bool canInteract = false; // 상호작용 가능한 상태인지 여부
    private static int interactedCount = 0; // 상호작용한 ATM 개수

    public GameObject Portal;
    public GameObject PortalUI; // 상호작용 UI

    public GameObject LastPortalUI;  // 포탈 오픈 UI

    private Coroutine interactionCoroutine;

    void Start()
    {
        interactionUI.SetActive(false);   
        Portal.SetActive(false);
        PortalUI.SetActive(false);
        interactionSlider.gameObject.SetActive(false); // 슬라이더 비활성화
        LastPortalUI.SetActive(false);
    }

    // 트리거가 시작될 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactionUI.SetActive(true); // 상호작용 UI를 보이게 함
        }
    }

    // 트리거가 끝날 때 호출되는 함수
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactionUI.SetActive(false); // 상호작용 UI를 숨김

            // 상호작용이 종료되면 슬라이더와 코루틴을 정리
            if (interactionCoroutine != null)
            {
                StopCoroutine(interactionCoroutine);
                interactionCoroutine = null;
            }
            interactionSlider.gameObject.SetActive(false);
            interactionSlider.value = 0;
        }
    }

    // 매 프레임마다 호출되는 업데이트 함수
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            if (interactionCoroutine == null)
            {
                interactionCoroutine = StartCoroutine(FillSlider());
            }
        }
    }

    IEnumerator FillSlider()
    {
        interactionSlider.gameObject.SetActive(true);
        interactionSlider.value = 0;

        while (interactionSlider.value < interactionSlider.maxValue)
        {
            interactionSlider.value += Time.deltaTime; // 슬라이더 채우기
            yield return null;
        }

        InteractWithATM();
        interactionSlider.gameObject.SetActive(false);
        interactionCoroutine = null;
    }

    void InteractWithATM()
    {
        // ATM과 상호작용하는 코드 작성
        interactedCount++; // 상호작용한 ATM 개수 증가

        // 상호작용이 완료되면 다음 함수 호출
        CheckAllATMInteracted();
    }

    void CheckAllATMInteracted()
    {
        // 모든 ATM이 상호작용 가능한 상태라면 Portal을 활성화
        if (interactedCount == 3)
        {
            Portal.SetActive(true);
            PortalUI.SetActive(true);
            LastPortalUI.SetActive(true);
        }
    }
}
