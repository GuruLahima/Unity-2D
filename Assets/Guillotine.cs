using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : MonoBehaviour
{
  [SerializeField] SliderJoint2D sliderJoint;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Debug.Log("Player hit the guillotine!");
      sliderJoint.useMotor = false;
    }
  }
}
