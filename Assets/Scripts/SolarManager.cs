using UnityEngine;
using UnityEngine.UI;

public class SolarManager : MonoBehaviour
{
    public Slider mutationGauge; // 독감자 게이지 UI Slider
    public float mutationSpeed = 10f; // 게이지 상승 속도
    private bool isInSunlight = false; // 햇볕에 감자가 있는지 확인
    private float currentGauge = 0f; // 현재 게이지 값
    public Text stageText; // 단계 표시 텍스트
    private int mutationStage = 0; // 현재 단계 (예: 0 = 일반, 1 = 독감자 1단계 ...)

    public GameObject currentPotato; // 현재 플레이어 감자
    public GameObject PotatoPrefabs; // 마지막 단계에서 생성할 새 감자 프리팹
    public Transform spawnPoint; // 새 감자가 생성될 위치
    public GameObject Solar; //햇볕 오브젝트

    void Start()
    {

    }

    private void Update()
    {
        if (isInSunlight)
        {

            // 게이지 증가
            currentGauge += mutationSpeed * Time.deltaTime;
            mutationGauge.value = currentGauge;

            // 단계 변경
            if (currentGauge >= mutationGauge.maxValue)
            {
                MutatePotato(); // 감자를 독감자로 변환
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Sunlight")) // 햇볕 트리거와 충돌
        {

            isInSunlight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sunlight")) // 햇볕 영역에서 벗어남
        {

            isInSunlight = false;
        }
    }

    private void MutatePotato()
    {

            mutationStage++; // 다음 단계로
            currentGauge = 0f; // 게이지 초기화
            mutationGauge.maxValue *= 2; // 다음 단계 게이지 증가
            mutationGauge.value = 0;
            TransformToNextStage();

        if (mutationStage == 1)
            stageText.text = "독감자 1단계"; // 단계 텍스트 업데이트
    }

    void TransformToNextStage()
    {
        Debug.Log("단계가 변경됨: " + mutationStage);

        // 기존 캐릭터 제거
        if (currentPotato != null)
        {
            Destroy(currentPotato);
            Destroy(Solar);
        }

        // 새로운 캐릭터 생성
        currentPotato = Instantiate(PotatoPrefabs, spawnPoint.position, Quaternion.identity);

    }

}