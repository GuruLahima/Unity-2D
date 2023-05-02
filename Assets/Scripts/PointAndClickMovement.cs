using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public float speed = 10;
    public Camera mainCam;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (!mainCam)
        {
            Debug.LogError("No main cam! This script won't work");
            Debug.Break();
        }

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    Vector2 clickPos;
    Vector2 origPos;
    float T = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // take mouse position on screen and convert it to world position
            clickPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            origPos = transform.position;
            Debug.Log("clickPos " + clickPos);
            Debug.Log("origPos " + origPos);

            // animation
            if (Mathf.Abs(origPos.x - clickPos.x) > Mathf.Abs(origPos.y - clickPos.y))
            {
                // horizontal animations
                if (clickPos.x < origPos.x)
                {
                    anim.Play("Ruby move left");
                }
                else
                {
                    anim.Play("Ruby move right");

                }
            }
            else
            {
                // vertical animations
                if (clickPos.y < origPos.y)
                {
                    anim.Play("Ruby move down");
                }
                else
                {
                    anim.Play("Ruby move up");
                }
            }
        }


        if (Vector2.Distance(transform.position, clickPos) < 0.1)
        {
            anim.Play("Ruby idle down");
            T = 0f;
        }
        else
        {
            T += Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(origPos, clickPos, T);
            // transform.position = Vector3.MoveTowards(transform.postion, clickPos, Time.deltaTime * speed);
        }

        //



    }
}
