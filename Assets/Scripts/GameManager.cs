using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted = false;
    public Action<bool> onGameEnded;
    public Action onGameStarted;
    private bool isTest;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isTest)
            return;

        if (Input.GetKeyDown(KeyCode.W))
            EndGame(true);
        if (Input.GetKeyDown(KeyCode.F))
            EndGame(false);
    }

    public void StartGame()
    {
        if (isGameStarted)
            return;
        isGameStarted = true;
        onGameStarted?.Invoke();
    }

    public void EndGame(bool win, float delay = 0)
    {
        if (!isGameStarted)
            return;
        isGameStarted = false;
        End(win, delay);
    }

    private async void End(bool win, float delay = 0f)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay));
        isGameStarted = true;
        onGameEnded?.Invoke(win);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
