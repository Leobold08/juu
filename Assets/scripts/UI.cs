using System.Collections;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public heartmovement Heart;
    public GameObject HitMarker;
    public Enemy enemy;
    public Playermovement playerMovement;
    public TextMeshProUGUI UiText;
    public TextMeshProUGUI InventoryButtonText;
    public bool InUi = true;
    public GameObject buttons;
    public float Phase = 0f;
    // Phase ----------------------------------------------------------
    public GameObject Phase1;
    public GameObject Phase2;
    // Phase ----------------------------------------------------------
    public GameObject SmallerArea;
    public GameObject InventoryPanel;
    public GameObject hppanel;
    public GameObject combatUI;
    public GameObject player;


    public void Start()
    {
        InUi = true;
    }
    public void Update()
    {
        ResetUi();

    }

    void ResetUi()
    {
        if (!combatUI.activeSelf)
        {
            Phase = 0f;
            InUi = true;
            buttons.SetActive(true);
            UiText.text = "";
            InventoryPanel.SetActive(false);
            hppanel.SetActive(true);
            combatUI.SetActive(false);
            Phase1.SetActive(false);
            Phase2.SetActive(false);
            SmallerArea.SetActive(false);
        }
        
    }

    public void Inventory()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryButtonText.text = "HP Menu";
            InventoryPanel.SetActive(true);
            hppanel.SetActive(false);
        }
        else
        {
            InventoryButtonText.text = "Inventory";
            InventoryPanel.SetActive(false);
            hppanel.SetActive(true);
        }
    }

    public void HealPlayer10()
    {
        hppanel.SetActive(true);
        InventoryPanel.SetActive(false);
        Heart.Heal(10f);
        UiText.text = "You feel better. You healed 10 HP.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_();
    }

    public void HealPlayer50()
    {
        hppanel.SetActive(true);
        InventoryPanel.SetActive(false);
        Heart.Heal(50f);
        UiText.text = "You feel better. You healed 10 HP.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_();
    }

    public void Attack10()
    {
        hppanel.SetActive(true);
        InventoryPanel.SetActive(false);
        StartCoroutine(HitmarkerDelay());
        enemy.Edmg(10f);
        UiText.text = "you hit enemy.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_();
    }

    public void Knife30()
    {
        hppanel.SetActive(true);
        InventoryPanel.SetActive(false);
        StartCoroutine(HitmarkerDelay());
        enemy.Edmg(30f);
        UiText.text = "you hit enemy.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_();
    }

    public void flee()
    {
        hppanel.SetActive(true);
        InventoryPanel.SetActive(false);
        UiText.text = "You run away.";
        NotInUi();
        Phase = 0f;
        combatUI.SetActive(false);
        player.SetActive(true);

    }



    public void NotInUi()
    {
        InUi = false;
    }


    public void Phase_()
    {
        if (Phase == 1f)
        {
            StartCoroutine(Phase1Sequence());
        }
        if (Phase == 2f)
        {
            StartCoroutine(Phase2Sequence());
        }
    }

    // Phase Sequences-----------------------------------------------------------
    private IEnumerator Phase1Sequence()
    {

        yield return StartCoroutine(SmallArea());

        Phase1.SetActive(true);
        yield return StartCoroutine(EndPhase1AfterDelay());
    }

    private IEnumerator Phase2Sequence()
    {

        Phase2.SetActive(true);
        yield return StartCoroutine(EndPhase2AfterDelay());
    }
    // Phase Sequences-----------------------------------------------------------

    //Timers-----------------------------------------------------------

    private IEnumerator SmallArea()
    {
        SmallerArea.SetActive(true);
        yield return new WaitForSeconds(1);
    }
    private IEnumerator HitmarkerDelay()
    {
        HitMarker.SetActive(true);
        yield return new WaitForSeconds(1);
        HitMarker.SetActive(false);
    }

    //timers-----------------------------------------------------------
    //end phase-----------------------------------------------------------
    private IEnumerator EndPhase1AfterDelay()
    {
        yield return new WaitForSeconds(8);
        Phase1.SetActive(false);
        SmallerArea.SetActive(false);
        InUi = true;
        buttons.SetActive(true);
        UiText.text = "";
    }

    private IEnumerator EndPhase2AfterDelay()
    {
        yield return new WaitForSeconds(15);
        SmallerArea.SetActive(false);
        InUi = true;
        buttons.SetActive(true);
        UiText.text = "";
    }
    //end phase-----------------------------------------------------------
}
