using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Last_WayPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("stop");
        if (collision.gameObject.CompareTag("Farmer"))
        {
            Debug.Log("농부가 집에 갔습니다! 게임 종료!");
            SceneManager.LoadScene("GameOver1");
        }
    }
}
