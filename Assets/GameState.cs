using UnityEngine;

public class GameState : MonoBehaviour
{
    public int mutationStage = 0; // 독감자 단계
    public Vector2[] holePositions; // 구멍 위치
    public int smallHoleCount = 0; // 작은 구멍 갯수
    public int largeHoleCount = 0; // 큰 구멍 갯수

    // 상태 저장
    public void SaveState(int stage, Vector2[] positions, int smallHoles, int largeHoles)
    {
        mutationStage = stage;
        holePositions = positions;
        smallHoleCount = smallHoles;
        largeHoleCount = largeHoles;

        Debug.Log("상태 저장 완료: Stage " + mutationStage);
    }

    // 상태 불러오기
    public void LoadState()
    {
        Debug.Log("상태 불러오기: Stage " + mutationStage);
        // 구멍 위치와 단계 설정에 따른 초기화 작업
    }
}
