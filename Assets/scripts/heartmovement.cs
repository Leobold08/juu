using UnityEngine;
using UnityEngine.UI;

public class heartmovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Slider healthSlider;
    private Rigidbody2D rb;
    public UI UI;
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float damageCooldown = 1f; // 1 second cooldown
    private float lastDamageTime = -1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Health();
    }

    void Start()
    {
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = CurrentHealth;
    }

    void Update()
    {
        Takedamage();
        Death();
        healthSlider.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("You are dead!");
            return;
        }

        if (UI.InUi == false)
        {
            // movement
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;
            rb.linearVelocity = movement;
        }
        else
        {
            rb.position = new Vector2(0, -2);
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
    }


    public void Health()
    {
        CurrentHealth = MaxHealth;
    }


    public void Takedamage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                CurrentHealth -= 10f;
                lastDamageTime = Time.time;
                Debug.Log("hp is " + CurrentHealth);
            }
            return;
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
        Debug.Log("Healed! hp is " + CurrentHealth);
    }

    // colliding method
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball10"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                CurrentHealth -= 10f;
                lastDamageTime = Time.time;
                Debug.Log("Collided with enemy! hp is " + CurrentHealth);
            }
        }
    }

    public void Death()
    {
        if (CurrentHealth <= 0)
        {
            Debug.Log("You died!");
        }
    }
}
