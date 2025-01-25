using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene2 : MonoBehaviour
{
    public void ChangeScene2(string InGame0)
    {
        SceneManager.LoadScene(InGame0);
    }
    public void GoToNextRound(string scene)
    {
        // 다음 라운드로 이동
        SceneManager.LoadScene(scene);
    }

    public void RestartGame(string scene1)
    {
        // 게임 초기화
        SceneManager.LoadScene(scene1);
    }
}
