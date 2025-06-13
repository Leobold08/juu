using System.Xml.XPath;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Enemy enemy;
    private Rigidbody2D rb;
    Camera mainCamera;
    public Assigndialogue assignDialogue; // Reference to the dialogue assignment script
    public bool canTalk = false;
    public float xptotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }


    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        xptotal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;
        rb.linearVelocity = movement;

        // Check for interaction
        if (canTalk && Input.GetKeyDown(KeyCode.Space))
        {
            assignDialogue.dialogue();
        }
        xptotal += enemy.xpGain;
        Debug.Log("Total XP: " + xptotal);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyEC"))
        {
            canTalk = true;
            assignDialogue = other.GetComponent<Assigndialogue>(); // Assign the dialogue from the trigger
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemyEC"))
        {
            canTalk = false;
        }
    }
}
