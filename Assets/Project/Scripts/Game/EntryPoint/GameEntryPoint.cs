using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameEntryPoint
{
    private const string PATH_LOADSCREEN = "[LOADSCREEN]";
    private static GameEntryPoint _instance;

    private UILoadScreenView _loadScreen;

    [RuntimeInitializeOnLoadMethod]
    public static void AutoStart()
    {
        Application.targetFrameRate = 60;

        _instance = new();
        _instance.Run();
        Debug.Log("Autostart");
    }

    public GameEntryPoint()
    {
        var loadscreenPrefab = Resources.Load<UILoadScreenView>(PATH_LOADSCREEN);
        _loadScreen = GameObject.Instantiate(loadscreenPrefab);
        GameObject.DontDestroyOnLoad(_loadScreen.gameObject);
    }

    private async void Run()
    {
        await StartGameplay();
    }

    private async UniTask StartGameplay()
    {
        _loadScreen.ActiveLoadingScreen(true);

        await LoadScene(Scenes.BOOTSTRAP);
        await LoadScene(Scenes.GAME);
        await UniTask.WaitForSeconds(2);

        var gameplayEntryPoint = GameObject.FindObjectOfType<GameplayEntryPoint>();
        await gameplayEntryPoint.Run();

        _loadScreen.ActiveLoadingScreen(false);
    }

    private async UniTask LoadScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
    }
}