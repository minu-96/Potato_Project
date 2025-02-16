using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRoundManager : MonoBehaviour
{
    public GameObject endRoundPanel; // 라운드 종료 화면 (UI 패널)
    public Text roundText; // 라운드 정보를 표시하는 Text
    public int currentRound = 0; // 현재 라운드 번호

    public int mutationStage;


    private void Start()
    {
        endRoundPanel.SetActive(false); // 패널 비활성화
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("stop");
        if (collision.gameObject.CompareTag("Farmer"))
        {
            Debug.Log("농부가 집에 갔습니다! 게임 종료!");
            EndRound();
        }
    }

    public void EndRound()
    {
        currentRound++; // 라운드 번호 증가
        //roundText.text = "Round " + currentRound + " Completed!"; // 메시지 업데이트
        // UI 활성화
        endRoundPanel.SetActive(true);
        Time.timeScale = 0f; // 일시 정지
    }

    
}