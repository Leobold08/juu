using UnityEngine;

public class heartmovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public UI UI;
    private float MaxHealth = 100f;
    private float CurrentHealth;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Health();
    }

    void Update()
    {
        Takedamage();
        Death();

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
            rb.position = new Vector2(0, 0);
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
            CurrentHealth -= 10f;
            Debug.Log("hp is " + CurrentHealth);
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
            CurrentHealth -= 10f;
            Debug.Log("Collided with enemy! hp is " + CurrentHealth);
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
