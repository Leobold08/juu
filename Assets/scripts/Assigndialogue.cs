using UnityEngine;

public class Assigndialogue : MonoBehaviour
{
    public GameObject Dialoguebox; // Reference to the dialogue box GameObject
    public GameObject player; // Reference to the player GameObject
    public Playermovement playerMovement; // Reference to the player movement script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void dialogue()
    {
        Dialoguebox.SetActive(true);
        player.SetActive(false);
        playerMovement.canTalk = false;
    }
}
