using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStage : MonoBehaviour
{
    public int mutationStage;

    public GameObject Potato0;
    public GameObject Potato1;

    public GameObject Farmer0;
    public GameObject Farmer1;

    void Awake()
    {
        // 씬이 로드될 때 `OnSceneLoaded` 실행
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"🎮 {scene.name} 씬이 로드됨!");

        // 데이터 불러오기
        RoundStateManager.Instance.LoadState(out int PoisonStage);

        // 저장된 데이터를 현재 상태에 반영
        mutationStage = PoisonStage;
        Debug.Log($"불러오기 완료ss: 단계 {mutationStage}");

        if (mutationStage == 0)
        {
            Destroy(Potato1);
            Destroy(Farmer1);
        }

        else if (mutationStage == 1)
        {
            Destroy(Potato0);
            Destroy(Farmer0);
        }

    }
    
}
