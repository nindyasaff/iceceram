using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D RB;
    public float ms = 10f;
    public float jf;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GameManager.instance.isPlaying == true)
        {
            float horiz = Input.GetAxisRaw("Horizontal"); // a,d , kiri kanan
            RB.velocity = new Vector2(ms * horiz, RB.velocity.y);
            if (Input.GetButtonDown("Jump"))
            {
                RB.AddForce(new Vector2(0, jf));
            }
        }
        
    }
}
