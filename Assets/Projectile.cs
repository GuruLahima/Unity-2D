using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float selfDestructDelay;

    Rigidbody2D rigidbody;

    public float debugForce;
    public Vector2 debugDirection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayedDeath", selfDestructDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() == true)
        {
            collision.gameObject.GetComponent<EnemyController>().Health -= damage;
        }

        if (!collision.gameObject.GetComponent<RubyController>())
        {
            Destroy(this.gameObject);
        }
    }

    void DelayedDeath()
    {
        Destroy(this.gameObject);
    }

    [ContextMenu("Test Launch")]
    void DebugTestLaunch()
    {
        LaunchProjectile(debugDirection, debugForce);
    }

    public void LaunchProjectile(Vector2 direction, float force)
    {
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    }

}
