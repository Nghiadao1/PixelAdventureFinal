using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWall : MonoBehaviour
{
    public float jumpForce = 10f;
    public float wallJumpForce = 15f;

    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isJumping)
        {
            isJumping = true;
            Vector2 wallNormal = collision.contacts[0].normal;
            Vector2 jumpDirection = Vector2.zero;

            if (wallNormal.y < 0f)
            {
                // Nếu tường nằm phía dưới
                jumpDirection = new Vector2(0f, 1f);
            }
            else
            {
                // Nếu tường nằm phía trên hoặc phía bên trái/phải
                jumpDirection = -wallNormal;
            }

            rb.velocity = jumpDirection * wallJumpForce;
        }
        else
        {
            isJumping = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
}
