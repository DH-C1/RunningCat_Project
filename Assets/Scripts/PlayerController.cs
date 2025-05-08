using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f;
    public float slideDuration = 0.5f;      //      임시

    private Rigidbody2D rb;
    private bool isGrounded = true;     //      점프를 위한 달리기 bool 값
    private bool isSliding = false;     //      슬라이딩 bool 값
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isSliding)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    IEnumerator Slide()
    {
        isSliding = true;
        
        // 콜라이더 사이즈를 줄여 몸을 낮추는 효과를 준다
        capsuleCollider.size = new Vector2(capsuleCollider.size.x, capsuleCollider.size.y * 0.5f);
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y - 0.25f);

        yield return new WaitForSeconds(slideDuration);

        // 콜라이더 사이즈 복구함으로 다시 일어서는 효과
        capsuleCollider.size = new Vector2(capsuleCollider.size.x, capsuleCollider.size.y * 2f);
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y + 0.25f);

        isSliding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
