using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    Camera mainCamera;
    public GameObject Dialoguebox;
    public GameObject player;

    private bool canTalk = false;

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
            Dialoguebox.SetActive(true);
            player.SetActive(false);
            canTalk = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyEC"))
        {
            canTalk = true;
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
