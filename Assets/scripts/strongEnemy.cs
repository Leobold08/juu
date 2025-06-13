using UnityEngine;
using System.Collections;
using TMPro;

public class strongEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Phase1; // Reference to the Phase1 GameObject
    public GameObject Phase2; // Reference to the Phase2 GameObject


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentEhp = MaxEhp; // Initialize current health to maximum                                                    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void death()
    {
        if (CurrentEhp <= 0f)
        {
            xpGain = 100f;
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
            ui.combatUI.SetActive(false);
            ui.player.SetActive(true);
            return;
        }
    }

     public override IEnumerator EndPhase1AfterDelay()
    {
        yield return new WaitForSeconds(8);
        ui.InUi = true;
        ui.buttons.SetActive(true);
        ui.UiText.text = "phase1strongenemycomplete";
    }

    public override IEnumerator EndPhase2AfterDelay()
    {
        yield return new WaitForSeconds(15);
        ui.InUi = true;
        ui.buttons.SetActive(true);
        ui.UiText.text = "phase2strongenemycomplete";
    }
    



}
