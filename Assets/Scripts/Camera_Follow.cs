using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (Player)
    public Vector3 offset;   // 카메라와 플레이어 사이의 거리
    public float smoothSpeed = 0.125f; // 카메라 이동 속도

    void LateUpdate()
    {
        if (target != null)
        {
            // 목표 위치 계산
            Vector3 desiredPosition = target.position + offset;

            // 부드럽게 이동
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라 위치 업데이트
            transform.position = smoothedPosition;
        }
    }
}