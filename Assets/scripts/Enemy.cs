using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float MaxEhp = 100f;
    public UI ui;
    public float CurrentEhp;
    public int CurrentPhase = 0; // Tracks the current phase
    public TextMeshProUGUI Phasetxt;
    public float xpGain = 0f;
    public Playermovement playermovement;

    void Start()
    {
        CurrentEhp = MaxEhp;
        // Example phases for this enemy
    }

    void Update()
    {

    }

    public virtual void Edmg(float amount)
    {
        CurrentEhp -= amount;
        Debug.Log("Enemy HP is " + CurrentEhp);

        // Example: Change phase based on health

        death();
    }

    public virtual void death()
    {
        if (CurrentEhp <= 0f)
        {
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
            return;
        }
    }
    public virtual IEnumerator EndPhase1AfterDelay()
    {
        // Default behavior (can be empty or have generic logic)
        yield return null;
    }
    
    public virtual IEnumerator EndPhase2AfterDelay()
    {
        // Default behavior (can be empty or have generic logic)
        yield return null;
    }

}
