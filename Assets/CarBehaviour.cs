using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] WheelJoint2D wheel;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            JointMotor2D newMotor = new JointMotor2D();
            newMotor.motorSpeed = speed;
            newMotor.maxMotorTorque = 10000;
            wheel.motor = newMotor;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            JointMotor2D newMotor = new JointMotor2D();
            newMotor.motorSpeed = -speed;
            newMotor.maxMotorTorque = 10000;
            wheel.motor = newMotor;
        }
        else
        {
            JointMotor2D newMotor = new JointMotor2D();
            newMotor.motorSpeed = 0;
            newMotor.maxMotorTorque = 10000;
            wheel.motor = newMotor;
        }
    }
}
