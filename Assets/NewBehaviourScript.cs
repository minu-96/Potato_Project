using UnityEngine;
using UnityEngine.UI;

public class PotatoGrowth : MonoBehaviour
{
    public GameObject[] potatoPrefabs; // 단계별 캐릭터 프리팹
    public Transform spawnPoint; // 캐릭터가 생성될 위치
    public GameObject currentPotato; // 현재 단계의 감자
    public Image potatoImageUI; // UI창에서 보여줄 감자의 이미지
    public Sprite[] potatoStageImages; // 단계별 UI 이미지
    public int currentStage = 0; // 현재 단계
    public float sunlightTime = 0f; // 햇볕을 받은 시간
    public float requiredTimeForNextStage = 5f; // 다음 단계로 가기 위한 햇볕 시간

    void Update()
    {
        if (IsInSunlight())
        {
            sunlightTime += Time.deltaTime;

            if (sunlightTime >= requiredTimeForNextStage)
            {
                sunlightTime = 0f; // 시간 초기화
                currentStage++; // 단계 증가

                if (currentStage < potatoPrefabs.Length)
                {
                    TransformToNextStage(); // 캐릭터 변경
                }
                else
                {
                    Debug.Log("최종 단계에 도달!");
                }
            }
        }
    }

    bool IsInSunlight()
    {
        // 햇볕 안에 있는지 확인하는 로직
        return true; // 임시로 true 반환
    }

    void TransformToNextStage()
    {
        Debug.Log("단계가 변경됨: " + currentStage);

        // 기존 캐릭터 제거
        if (currentPotato != null)
        {
            Destroy(currentPotato);
        }

        // 새로운 캐릭터 생성
        currentPotato = Instantiate(potatoPrefabs[currentStage], spawnPoint.position, Quaternion.identity);

        // 단계별 UI 이미지 업데이트
        if (currentStage < potatoStageImages.Length)
        {
            Debug.Log("Updated Image to: " + potatoStageImages[currentStage].name);
            potatoImageUI.sprite = null; // 기존 Sprite를 초기화
            potatoImageUI.sprite = potatoStageImages[currentStage];
            Canvas.ForceUpdateCanvases(); // 캔버스 강제 갱신
            
        }

    }
}
