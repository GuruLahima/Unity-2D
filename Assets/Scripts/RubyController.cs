using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public string horizontalAxisName;
    public string verticalAxisName;
    public float speed;
    public float timeBeingInvincible;
    // referenc to health bar image
    public Image healthBarUI;

    public Animator anim;
    public Rigidbody2D rb;

    public GameObject projectilePrefab;
    public Vector3 projectileOffset;
    public float projectileSpeed;

    [SerializeField] private int health = 10;

    private bool isInvincible;
    private float invincibilityTimer;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // if we took damage, stop taking damage for a certain amount of time
            int oldHealth = health;



            if (oldHealth > value)
            {
                // taking damage

                if (!isInvincible)
                {
                    // one way of limiting health
                    health = Mathf.Clamp(value, 0, maxHealth);
                }

                // we took some damage
                isInvincible = true;
            }
            else
            {
                // gaining health
                health = Mathf.Clamp(value, 0, maxHealth);
            }

            // if ruby reaches 0 or bellow 0 hitpoints, she should die
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }

            // visual feedback
            if (maxHealth == 0)
            {
                healthBarUI.fillAmount = 0;
            }
            else
            {
                if (healthBarUI != null)
                    healthBarUI.fillAmount = (float)health / (float)maxHealth;
            }

            // second way of limiting max health
            /*            if (health > maxHealth)
                        {
                            health = maxHealth;
                        }  */

        }
    }

    public int maxHealth = 10;

    private void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        invincibilityTimer = timeBeingInvincible;

        // visual feedback
        if(maxHealth == 0)
        {
            healthBarUI.fillAmount = 0;
        }
        else
        {
            if (healthBarUI != null)
                healthBarUI.fillAmount = (float)health / (float)maxHealth;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // movement code
        /*transform.Translate(
            Input.GetAxis(horizontalAxisName) * Time.deltaTime * speed,
            Input.GetAxis(verticalAxisName) * Time.deltaTime * speed,
            0);*/


        // animation code
        // check velocity
        if(Input.GetAxis(horizontalAxisName) > 0)
        // if(rb.velocity.x > 0.1f)
        {
            anim.Play("Ruby move right");
        }
        else if(Input.GetAxis(horizontalAxisName) < 0)
        //else if(rb.velocity.x < -0.1f)
        {
            anim.Play("Ruby move left");
        }
        else if(Input.GetAxis(verticalAxisName) > 0)
        //else if(rb.velocity.y > 0.1f)
        {
            anim.Play("Ruby move up");
        }
        else if(Input.GetAxis(verticalAxisName) < 0)
        //else if(rb.velocity.y < -0.1f)
        {
            anim.Play("Ruby move down");
        }
        else
        {
            anim.Play("Ruby idle down");
        }

        currentHorizontalInput = Input.GetAxis(horizontalAxisName);
        currentVerticalInput = Input.GetAxis(verticalAxisName);

        // temporary invincibility code
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if(invincibilityTimer <= 0)
            {
                isInvincible = false;
                invincibilityTimer = timeBeingInvincible;
            }
        }

        // shooting projectiles code
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(projectilePrefab, this.transform.position + projectileOffset, Quaternion.identity);
            
            newProjectile.GetComponent<Projectile>().LaunchProjectile(this.rb.velocity.normalized, projectileSpeed);

        }

    }

    float currentHorizontalInput;
    float currentVerticalInput;

    // 30 frames per second
    void FixedUpdate()
    {

        Vector2 movementForce = new Vector2(
        currentHorizontalInput * Time.deltaTime * speed,
        currentVerticalInput * Time.deltaTime * speed);
        rb.AddForce(movementForce, ForceMode2D.Impulse);
        

    }

}
