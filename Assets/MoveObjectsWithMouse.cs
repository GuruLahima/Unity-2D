using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectsWithMouse : MonoBehaviour
{
    [SerializeField] TargetJoint2D tj;

    private Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        tj = GetComponent<TargetJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // take position of mouse and covert it to world space
        Vector2 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        tj.target = mousePos;
    }
}
