using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    [Header("Input axis")]
    public string horizontalAxisName;
    public string verticalAxisName;
    public string jumpAxisName;

    [Header("Movement parameters")]
    public float speed;
    public float jumpSpeed;

    Animator anim;
    Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // movement code
        Vector2 movementForce = new Vector2(
            Input.GetAxis(horizontalAxisName) * Time.deltaTime * speed,
            0);
        rb.AddForce(movementForce, ForceMode2D.Impulse);

        // jump code
        if (Input.GetButtonDown(jumpAxisName))
        {
            /*            Vector2 jumpForce = new Vector2(
                                0,
                                jumpSpeed);
                        rb.AddForce(jumpForce, ForceMode2D.Impulse);*/
            rb.gravityScale = -rb.gravityScale;
        }


        // animation code
        if (Input.GetAxis(horizontalAxisName) > 0)
        {
            anim.Play("Ruby move right");
        }
        else if (Input.GetAxis(horizontalAxisName) < 0)
        {
            anim.Play("Ruby move left");
        }
        else if (Input.GetAxis(verticalAxisName) > 0)
        {
            anim.Play("Ruby move up");
        }
        else if (Input.GetAxis(verticalAxisName) < 0)
        {
            anim.Play("Ruby move down");
        }
        else
        {
            anim.Play("Ruby idle down");
        }

    }
}
