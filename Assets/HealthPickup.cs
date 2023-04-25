using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthBonus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController ruby = collision.GetComponent<RubyController>();
        // check to see if object we collided with is Ruby
        if (ruby)
        {
            // try to give health to Ruby
            ruby.Health -= healthBonus;

            Destroy(this.gameObject);
        }
    }
}
