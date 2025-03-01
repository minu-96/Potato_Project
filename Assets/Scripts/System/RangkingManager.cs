using UnityEngine.UI;
using UnityEngine; // Unity의 기본 기능 (GameObject, Transform 등)
using System.Collections; // 코루틴 및 IEnumerator 관련 기능
using System.Collections.Generic; // List, Dictionary 같은 컬렉션 사용 시 필요

public class RangkingManager : MonoBehaviour
{
    public Text rankingText;

    private void Start()
    {
        ShowRanking();
    }

    void ShowRanking()
    {
        rankingText.text = "🏆 랭킹 🏆\n";
        for (int i = 0; i < 10; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            rankingText.text += $"{i + 1}위: {score} 점\n";
        }
    }
}
