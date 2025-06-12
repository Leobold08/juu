using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public float MaxEhp = 100f;
    public float CurrentEhp;
    public Slider EhealthSlider;



    void Start()
    {
        EhealthSlider.maxValue = MaxEhp;
        EhealthSlider.value = CurrentEhp;
        CurrentEhp = MaxEhp;
    }

    void Update()
    {
        EhealthSlider.value = CurrentEhp;
    }

    public virtual void Edmg(float amount)
    {
        CurrentEhp -= amount;
        Debug.Log("Enemy HP is " + CurrentEhp);
        if (CurrentEhp <= 0f)
        {
            EhealthSlider.value = 0f;
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
            return;
        }
    }
}
