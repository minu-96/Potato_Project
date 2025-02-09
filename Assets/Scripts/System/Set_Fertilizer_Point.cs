using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set_Fertilizer_Point : MonoBehaviour
{
    public Vector2 areaMin; //랜덤 위치 최소값
    public Vector2 areaMax; //랜덤 위치 최대값
    public float time = 0f; //생성 시간


    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(SetTime());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SetTime()
    {
        yield return new WaitForSeconds(time); // 일정 시간 대기

        transform.position = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y)); //비료 생성
    }
}
