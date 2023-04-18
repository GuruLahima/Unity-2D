using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public string horizontalAxisName;
    public string verticalAxisName;
    public float speed;

    public Animator anim;
    public Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement code
        /*transform.Translate(
            Input.GetAxis(horizontalAxisName) * Time.deltaTime * speed,
            Input.GetAxis(verticalAxisName) * Time.deltaTime * speed,
            0);*/
        Vector2 movementForce = new Vector2(
            Input.GetAxis(horizontalAxisName) * Time.deltaTime * speed,
            Input.GetAxis(verticalAxisName) * Time.deltaTime * speed);
        rb.AddForce(movementForce, ForceMode2D.Impulse);

        // animation code
        // check velocity
        if(Input.GetAxis(horizontalAxisName) > 0)
        // if(rb.velocity.x > 0.1f)
        {
            anim.Play("Ruby move right");
        }
        else if(Input.GetAxis(horizontalAxisName) < 0)
        //else if(rb.velocity.x < -0.1f)
        {
            anim.Play("Ruby move left");
        }
        else if(Input.GetAxis(verticalAxisName) > 0)
        //else if(rb.velocity.y > 0.1f)
        {
            anim.Play("Ruby move up");
        }
        else if(Input.GetAxis(verticalAxisName) < 0)
        //else if(rb.velocity.y < -0.1f)
        {
            anim.Play("Ruby move down");
        }
        else
        {
            anim.Play("Ruby idle down");
        }

    }
}
