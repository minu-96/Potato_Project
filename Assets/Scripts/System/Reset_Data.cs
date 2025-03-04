using UnityEngine;
using UnityEngine.UI;

public class Reset_Data : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll(); // 모든 PlayerPrefs 데이터 삭제
        PlayerPrefs.Save();
    }
}
