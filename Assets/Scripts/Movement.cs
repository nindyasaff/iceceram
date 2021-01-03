using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D RB;
    public float ms = 10f;
    public float jf;
    private bool isJump = false;
    float horiz;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!isJump)
        {
            RB.AddForce(new Vector2(0, jf));
            isJump = true;
        }
    }

    public void MovementLeft()
    {
        RB.velocity = new Vector2(ms * 1, RB.velocity.y);
    }

    public void MovementRight()
    {
        RB.velocity = new Vector2(ms * -1, RB.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
