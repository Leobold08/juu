using System.Collections;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public heartmovement player;
    public Enemy enemy;
    public TextMeshProUGUI UiText;
    public bool InUi = true;
    public GameObject buttons;
    public float Phase = 0f;
    public GameObject Phase1;
    public float Timer = 3f;

    public void Start()
    {
        InUi = true;
        Phase = 0f;
    }

    public void Update()
    {
    }

    public void HealPlayer10()
    {
        player.Heal(10f);
        UiText.text = "You feel better. You healed 10 HP.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_1();
    }

    public void Attack10()
    {
        enemy.Edmg(10f);
        UiText.text = "you hit enemy.";
        buttons.SetActive(false);
        NotInUi();
        Phase += 1f;
        Debug.Log("Phase is now " + Phase);
        Phase_1();
    }


    public void NotInUi()
    {
        InUi = false;
    }


    public void Phase_1()
    {
        if (Phase == 1f)
        {
            Phase1.SetActive(true);
            StartCoroutine(EndPhaseAfterDelay());
        }
    }

    private IEnumerator EndPhaseAfterDelay()
    {
        yield return new WaitForSeconds(Timer);
        Phase1.SetActive(false);
        buttons.SetActive(true);
        InUi = true;
        UiText.text = "";
    }
}
