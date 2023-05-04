using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    SliderJoint2D sj;

    Vector3 originalPosition;

    public bool recentlySwitchedDirection;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SliderJoint2D>();
        originalPosition = transform.position;
        recentlySwitchedDirection = false;
        timer = 0.5f;
        Debug.Log("max " + sj.limits.max);
        Debug.Log("min " + sj.limits.min);
    }

    // Update is called once per frame
    void Update()
    {
        // proveri dali ovoj object stignal do leviot limit
        if(transform.position.x <= originalPosition.x - Mathf.Abs(sj.limits.min) && !recentlySwitchedDirection)
        {
            Debug.Log("change direction to right");
            JointMotor2D newMotor = new JointMotor2D();
            newMotor.motorSpeed = -sj.motor.motorSpeed;
            newMotor.maxMotorTorque = 10000;
            sj.motor = newMotor;
            recentlySwitchedDirection = true;
        }
        else if (transform.position.x >= originalPosition.x + Mathf.Abs(sj.limits.max) && !recentlySwitchedDirection)
        {
            Debug.Log("change direction to left");

            JointMotor2D newMotor = new JointMotor2D();
            newMotor.motorSpeed = -sj.motor.motorSpeed;
            newMotor.maxMotorTorque = 10000;
            sj.motor = newMotor;
            recentlySwitchedDirection = true;
        }

        if (recentlySwitchedDirection)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                recentlySwitchedDirection = false;
                timer = 0.5f;
            }
        }
        
    }
}
