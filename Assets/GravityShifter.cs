using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShifter : MonoBehaviour
{
  // reference to the rigidbody of the player character.
  // we need it to make the gravity magnitude dependable on the gravity scale of the character rigidbody
  [SerializeField] Rigidbody2D rb;

  private void Start()
  {
    if (rb == null)
      rb = GetComponent<Rigidbody2D>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Left Gravity Collider"))
    {
      // change gravity
      Physics2D.gravity = new Vector2(-9.8f * rb.gravityScale, 0);
      // rotate sprite
      transform.rotation = Quaternion.Euler(0, 0, -90);
      // 
    }
    else if (other.gameObject.CompareTag("Right Gravity Collider"))
    {
      Physics2D.gravity = new Vector2(9.8f * rb.gravityScale, 0);
      // rotate sprite
      transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    else if (other.gameObject.CompareTag("Top Gravity Collider"))
    {
      Physics2D.gravity = new Vector2(0, 9.8f * rb.gravityScale);
      // rotate sprite
      transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    else if (other.gameObject.CompareTag("Down Gravity Collider"))
    {
      Physics2D.gravity = new Vector2(0, -9.8f * rb.gravityScale);
      // rotate sprite
      transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  }
}
