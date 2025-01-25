using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmerMovement : MonoBehaviour
{
    public Transform[] waypoints; // 경로 점(waypoint)을 저장하는 배열
    public float speed = 2f; // 이동 속도
    public float chaseSpeed = 4f; // 추적 시 속도
    public float detectionRange = 5f; // 감자를 감지할 범위
    public Transform potato; // 감자의 Transform

    private int currentWaypointIndex = 0; // 현재 이동 중인 waypoint
    private bool isChasing = false; // 추적 중인지 여부

    public GameObject exclamationMark;

    public AudioClip alertSound;
    private AudioSource audioSource;

  

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


    }

    void Update()
    {

        if (isChasing)
        {
            // 감자를 추적
            ChasePotato();
        }
        else
        {
            // 정해진 경로를 따라 이동
            MoveAlongWaypoints();

            // 감자 감지
            DetectPotato();
        }
    }

    void MoveAlongWaypoints()
    {
        // 현재 목표 Waypoint까지 이동
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);


        // 목표 Waypoint에 도달했는지 확인
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // 다음 Waypoint로 이동
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Waypoint 반복
            }
        }
    }

    void DetectPotato()
    {
        // 감자가 감지 범위 내에 있는지 확인
        if (Vector2.Distance(transform.position, potato.position) <= detectionRange)
        {
            isChasing = true; // 추적 시작
            audioSource.PlayOneShot(alertSound);
            exclamationMark.SetActive(true); // 느낌표 활성화
        }
    }

    void ChasePotato()
    {
        // 감자를 향해 이동
        transform.position = Vector2.MoveTowards(transform.position, potato.position, chaseSpeed * Time.deltaTime);


        // 감자를 놓쳤는지 확인
        if (Vector2.Distance(transform.position, potato.position) > detectionRange)
        {
            isChasing = false; // 추적 종료
            exclamationMark.SetActive(false); // 느낌표 ㅂㅣ활성화
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Potato"))
        {
            Debug.Log("감자가 잡혔습니다! 게임 종료!");
            SceneManager.LoadScene("GameOver0");
        }
    }
    
}
