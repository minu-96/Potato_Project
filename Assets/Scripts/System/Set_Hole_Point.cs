using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set_Hole_Point : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 오브젝트 프리팹
    public Transform holeTransform; // 부모가 될 Hole 오브젝트
    public float spawnInterval = 3f; // 생성 간격 (초)
    public int spawnCount = 3; // 한 번에 생성할 개수
    public Vector2 areaMin; //랜덤 위치 최소값
    public Vector2 areaMax; //랜덤 위치 최대값

    private void Start()
    {
        StartCoroutine(SpawnObjectsRoutine()); // 코루틴 실행
    }

    private IEnumerator SpawnObjectsRoutine()
    {
            yield return new WaitForSeconds(spawnInterval); // 일정 시간 대기

            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 randomPosition = GetRandomPosition(); // 랜덤 위치 계산
                GameObject spawnedObject = Instantiate(objectPrefab, randomPosition, Quaternion.identity);

                if (holeTransform != null)
                {
                    spawnedObject.transform.SetParent(holeTransform); // Hole을 부모로 설정
                }
            }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(areaMin.x, areaMax.x);
        float randomY = Random.Range(areaMin.y, areaMax.y);
        return new Vector3(randomX, randomY, 0f) + holeTransform.position; // Hole 위치 기준으로 랜덤 위치 반환
    }
}


