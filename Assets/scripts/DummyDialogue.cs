using UnityEngine;
using System.Collections;
using TMPro;

public class DummyDialogue : MonoBehaviour
{
    public TextMeshProUGUI EnemysDiaBox;
    public GameObject YesB;
    public GameObject NoB;
    public float typeSpeed = 0.06f; // Speed of each letter
    public GameObject BattleUI;
    public GameObject Dialoguebox;
    public GameObject player;
    public Enemy ActiveEnemy;

    void OnEnable()
    {
        YesB.SetActive(false);
        NoB.SetActive(false);
        StartCoroutine(Dialogue());
    }

    public void YES()
    {
        StartCoroutine(Yes());
    }
    public void NO()
    {
        StartCoroutine(No());
    }

    public IEnumerator Yes()
    {
        YesB.SetActive(false);
        NoB.SetActive(false);
        yield return StartCoroutine(TypeText("*You attacked the dummy. But why?*"));
        yield return new WaitForSeconds(1);
        BattleUI.SetActive(true);
        Dialoguebox.SetActive(false);
        UI ui = FindFirstObjectByType<UI>();
        if (ui != null && ActiveEnemy != null)
        {
            ui.enemy = ActiveEnemy.GetComponent<Enemy>();
            Debug.Log("Enemy HP is " + ui.enemy.CurrentEhp);
            Debug.Log("Enemy is " + ui.enemy);
        }
        else
        {
            Debug.LogWarning("UI or ActiveEnemy not found!");
        }
    }

    public IEnumerator No()
    {
        YesB.SetActive(false);
        NoB.SetActive(false);
        yield return StartCoroutine(TypeText("*You choose to not attack it*"));
        yield return new WaitForSeconds(1);
        player.SetActive(true);
        Dialoguebox.SetActive(false);
    }

    private IEnumerator Dialogue()
    {
        yield return StartCoroutine(TypeText("*You started Talking to the dummy*"));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(TypeText("*It didn't answer*"));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(TypeText("*Do you want to fight it?*"));
        YesB.SetActive(true);
        NoB.SetActive(true);
    }

    private IEnumerator TypeText(string message)
    {
        EnemysDiaBox.text = "";
        foreach (char c in message)
        {
            EnemysDiaBox.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
