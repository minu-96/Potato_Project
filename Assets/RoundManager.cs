using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundGameManager : MonoBehaviour
{
    public GameObject endRoundPanel; // 라운드 종료 화면 (UI 패널)
    public Text roundText; // 라운드 정보를 표시하는 Text
    private int currentRound = 1; // 현재 라운드 번호

    public List<Vector2> currentHolePositions = new List<Vector2>();
    public int mutationStage;
    public int smallHoleCount;
    public int largeHoleCount;

    public GameObject smallHolePrefab;

    private void Start()
    {
        endRoundPanel.SetActive(false); // 패널 비활성화
    }

    public void EndRound()
    {
        // 상태 저장
        GameStateManager.Instance.SaveState(mutationStage, smallHoleCount, largeHoleCount, currentHolePositions);
        roundText.text = "Round " + currentRound + " Completed!"; // 메시지 업데이트
        // UI 활성화
        endRoundPanel.SetActive(true);
        Time.timeScale = 0f; // 일시 정지
    }
    
    public void StartNextRound()
    {
        currentRound++; // 라운드 번호 증가

        // 데이터 불러오기
        GameStateManager.Instance.LoadState(out int nextStage, out int smallHoles, out int largeHoles, out List<Vector2> holes);

        // 저장된 데이터를 현재 상태에 반영
        mutationStage = nextStage;
        smallHoleCount = smallHoles;
        largeHoleCount = largeHoles;
        currentHolePositions = holes;

        // UI 닫기 및 다음 라운드 준비
        endRoundPanel.SetActive(false); // 패널 비활성화
        Time.timeScale = 1f; // 게임 재개

        // 다음 라운드 설정
        SetupNextRound();
    }

    private void SetupNextRound()
    {
        Debug.Log("다음 라운드를 준비합니다: Round " + currentRound);
        // 예: 독감자 상태 및 구멍 초기화
        GameState gameState = FindObjectOfType<GameState>();

        // 저장된 상태 가져오기
        int nextStage = gameState.mutationStage + 1;
        Vector2[] newHolePositions = GenerateRandomHolePositions(); // 새 구멍 위치 생성

        // 상태 저장
        gameState.SaveState(nextStage, newHolePositions, 5, 3); // 다음 라운드에 필요한 구멍 정보 저장

        // 독감자 상태 및 구멍 반영
        Debug.Log("독감자 단계: " + nextStage);
        Debug.Log("새 구멍 갯수: " + newHolePositions.Length);

        Debug.Log($"다음 라운드 설정: 단계 {mutationStage}, 작은 구멍 {smallHoleCount}, 큰 구멍 {largeHoleCount}");

        // 구멍 및 독감자 상태를 초기화
        SpawnHoles(currentHolePositions);
        UpdateMutationStage();
    }

    private Vector2[] GenerateRandomHolePositions()
    {
        int holeCount = Random.Range(5, 10); // 랜덤한 구멍 갯수
        Vector2[] positions = new Vector2[holeCount];

        for (int i = 0; i < holeCount; i++)
        {
            positions[i] = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // 랜덤 위치 생성
        }

        return positions;
    }

    private void SpawnHoles(List<Vector2> holePositions)
    {
        foreach (Vector2 position in holePositions)
        {
            // 구멍 프리팹 생성 (예: 작은 구멍)
            GameObject hole = Instantiate(smallHolePrefab, position, Quaternion.identity);
            Debug.Log($"구멍 생성 위치: {position}");
        }
    }

    private void UpdateMutationStage()
    {
        Debug.Log($"현재 독감자 단계: {mutationStage}");
        // 독감자의 상태를 단계에 맞게 초기화
        // 예: 독감자 프리팹을 업데이트하거나 UI를 변경
    }
}
/*
using UnityEngine;
using UnityEngine.UI;

public class SolarManager : MonoBehaviour
{
    public Slider mutationGauge; // 독감자 게이지 UI Slider
    //public SpriteRenderer potatoImage; // 감자의 이미지
    public float mutationSpeed = 10f; // 게이지 상승 속도
    private bool isInSunlight = false; // 햇볕에 감자가 있는지 확인
    private float currentGauge = 0f; // 현재 게이지 값
    public Text stageText; // 단계 표시 텍스트
    public int mutationStage = 0; // 현재 단계 (예: 0 = 일반, 1 = 독감자 1단계 ...)

    public Image stageImage; // UI Image 컴포넌트 연결
    public Sprite[] stageSprites; // 단계별 Sprite를 저장 (크기: 3)

    public GameObject currentPotato; // 현재 플레이어 감자
    public GameObject[] PotatoPrefabs; // 마지막 단계에서 생성할 새 감자 프리팹
    public Transform spawnPoint; // 새 감자가 생성될 위치
    public int currentStage = 0;

    void Start()
    {
        UpdateStageUI();
    }

    private void Update()
    {
        if (isInSunlight)
        {

            // 게이지 증가
            currentGauge += mutationSpeed * Time.deltaTime;
            mutationGauge.value = currentGauge;

            // 단계 변경
            if (currentGauge >= mutationGauge.maxValue && mutationStage < stageSprites.Length - 1)
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

        if (mutationStage < stageSprites.Length - 1) // 마지막 단계가 아니면
        {
            mutationStage++; // 다음 단계로
            currentGauge = 0f; // 게이지 초기화
            mutationGauge.maxValue *= 2; // 다음 단계 게이지 증가
            TransformToNextStage();
            UpdateStageUI();

        }


        if (mutationStage == 1)
            stageText.text = "독감자 1단계"; // 단계 텍스트 업데이트

        else if (mutationStage == 2)
            stageText.text = "독감자 2단계"; // 단계 텍스트 업데이트

        else if (mutationStage == 3)
            stageText.text = "독감자 3단계"; // 단계 텍스트 업데이트

        else if (mutationStage == 4)
            stageText.text = "독감자 4단계"; // 단계 텍스트 업데이트

    }

    private void UpdateStageUI()
    {
        stageImage.sprite = stageSprites[currentStage]; // 현재 단계의 Sprite로 변경
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
        currentPotato = Instantiate(PotatoPrefabs[currentStage], spawnPoint.position, Quaternion.identity);

    }

}

*/
