using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject winPanel, losePanel;
    public Transform[] winPanelComponents, losePanelComponents;
    public Transform button_StartGame;
    public Button buttonRetry, buttonContinue;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        if (!GameManager.Instance.isGameStarted)
            GameManager.Instance.StartGame();
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    private void GameStarted()
    {

    }

    private void GameEnded(bool isWin)
    {
        if (!GameManager.Instance.isGameStarted)
            return;
        if (isWin)
        {
            EnableWinPanel();
            return;
        }

        EnableLosePanel();
    }

    private async void EnableWinPanel()
    {
        winPanel.SetActive(true);
        for (int i = 0; i < winPanelComponents.Length; i++)
        {
            winPanelComponents[i].DOPunchScale(Vector3.one * 1.05f, 1f,5,0.5f).SetEase(Ease.OutSine);
            await Task.Delay(TimeSpan.FromSeconds(0.15f));
        }
        buttonContinue.interactable = true;
    }

    private async void EnableLosePanel()
    {
        losePanel.SetActive(true);
        for (int i = 0; i < losePanelComponents.Length; i++)
        {
            losePanelComponents[i].DOPunchScale(Vector3.one * 1.05f,1f,5,0.5f).SetEase(Ease.OutSine);
            await Task.Delay(TimeSpan.FromSeconds(0.15f));
        }
        buttonRetry.interactable = true;
    }

    private void OnEnable()
    {
        GameManager.Instance.onGameStarted += GameStarted;
        GameManager.Instance.onGameEnded += GameEnded;
    }

    private void OnDisable()
    {
        GameManager.Instance.onGameStarted -= GameStarted;
        GameManager.Instance.onGameEnded -= GameEnded;
        KilTweens();
    }

    private void KilTweens()
    {
        for (int i = 0; i < losePanelComponents.Length; i++)
        {
            losePanelComponents[i].DOKill();
        }

        for (int i = 0; i < winPanelComponents.Length; i++)
        {
            winPanelComponents[i].DOKill();
        }
    }
}
