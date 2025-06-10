using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float MaxEhp = 100f;
    public float CurrentEhp;



    void Start()
    {
        CurrentEhp = MaxEhp;
    }

    public void Edmg(float amount)
    {
        CurrentEhp -= amount;
        Debug.Log("Enemy HP is " + CurrentEhp);
        if (CurrentEhp <= 0f)
        {
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
            return;
        }
    }
}
