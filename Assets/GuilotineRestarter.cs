using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuilotineRestarter : MonoBehaviour
{
  [SerializeField] SliderJoint2D sliderJoint;

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Guillotine is restarting");

    if (other.tag == "Respawn")
    {
      Debug.Log("Guillotine is restarting");
      sliderJoint.useMotor = true;
    }
  }
}
