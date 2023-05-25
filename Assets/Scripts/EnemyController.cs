using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
  public float speed;
  public bool vertical;
  public float changeTime = 3.0f;

  Rigidbody2D rigidbody2D;
  float timer;
  int direction = 1;

    public Image healthBar;

    int health;
    public int maxHealth;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            healthBar.fillAmount = (float)health / (float)maxHealth;

            // code for destroying when zero health
            if (health <= 0)
            {
                // vfx
                // sfx
                // particle
                // camera effect

                // destroy enemy
                Destroy(this.gameObject);
            }

        }
    }

  // Start is called before the first frame update
  void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    timer = changeTime;

    Health = maxHealth;
  }

  void Update()
  {
    timer -= Time.deltaTime;

    if (timer < 0)
    {
      direction = -direction;
      timer = changeTime;
    }
  }

  void FixedUpdate()
  {
    Vector2 position = rigidbody2D.position;

    if (vertical)
    {
      position.y = position.y + Time.deltaTime * speed * direction;
    }
    else
    {
      position.x = position.x + Time.deltaTime * speed * direction;
    }

    rigidbody2D.MovePosition(position);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    RubyController player = other.gameObject.GetComponent<RubyController>();

    if (player != null)
    {
      player.Health -= 1;
    }
  }
}


