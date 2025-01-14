using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도

    private Rigidbody2D rb; // Rigidbody2D 참조
    private Vector2 movement; // 입력값 저장

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 입력값 받아오기
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D 또는 좌우 화살표
        movement.y = Input.GetAxisRaw("Vertical"); // W, S 또는 상하 화살표
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 이용해 움직이기
        rb.velocity = movement * moveSpeed;
    }
}