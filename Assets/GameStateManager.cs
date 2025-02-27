using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 싱글톤 패턴

    // 저장할 데이터
    public int mutationStage; // 독감자 단계
    public int smallHoleCount; // 작은 구멍 갯수
    public int largeHoleCount; // 큰 구멍 갯수
    public List<Vector2> holePositions = new List<Vector2>(); // 구멍 위치 목록

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 데이터 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 제거
        }
    }

    // 현재 상태 저장
    public void SaveState(int stage, int smallHoles, int largeHoles, List<Vector2> positions)
    {
        mutationStage = stage;
        smallHoleCount = smallHoles;
        largeHoleCount = largeHoles;
        holePositions = new List<Vector2>(positions); // 기존 데이터를 복사

        Debug.Log($"상태 저장 완료: 단계 {stage}, 작은 구멍 {smallHoles}, 큰 구멍 {largeHoles}, 구멍 위치 {positions.Count}개");
    }

    // 저장된 상태 불러오기
    public void LoadState(out int stage, out int smallHoles, out int largeHoles, out List<Vector2> positions)
    {
        stage = mutationStage;
        smallHoles = smallHoleCount;
        largeHoles = largeHoleCount;
        positions = new List<Vector2>(holePositions); // 복사된 데이터 반환

        Debug.Log($"상태 불러오기: 단계 {stage}, 작은 구멍 {smallHoles}, 큰 구멍 {largeHoles}, 구멍 위치 {positions.Count}개");
    }
}
