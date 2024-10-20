using UnityEngine;
using TMPro;

public class EndGameView : MonoBehaviour
{
    private StatManager statManager;
    private TMP_Text text;

    private void Awake()
    {
        statManager = Finder.StatManager;
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Finder.EventChannels.OnPlayerDead += OnPlayerDead;
        Finder.EventChannels.OnPlayerWin += OnPlayerWin;
    }

    private void OnDisable()
    {
        Finder.EventChannels.OnPlayerDead -= OnPlayerDead;
        Finder.EventChannels.OnPlayerWin -= OnPlayerWin;
    }

    private void OnPlayerDead()
    {
        ShowEndMessage(statManager.LoseMessage);
    }
    private void OnPlayerWin()
    {
        ShowEndMessage(statManager.WinMessage);
    }

    private void ShowEndMessage(string message)
    {
        text.text =  message;
        text.gameObject.SetActive(true);

        Time.timeScale = 0;
    }
}
