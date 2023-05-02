using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("We were stepped on by: " + collision.name);

        RubyController ruby = collision.GetComponent<RubyController>();
        if (ruby)
        {

            ruby.Health -= damage;

        }
    }
}
