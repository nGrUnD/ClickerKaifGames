using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private const string PATH_INTERFACE = "[INTERFACE]";
    private static GameEntryPoint _instance;
    private UIRootView _interfaces;

    [RuntimeInitializeOnLoadMethod]
    public static void AutoStart()
    {
        Application.targetFrameRate = 60;

        _instance = new();
        _instance.Run();
        Debug.Log("Autostart");
    }

    private GameEntryPoint()
    {
        var interfacePrefab = Resources.Load<UIRootView>(PATH_INTERFACE);
        _interfaces = GameObject.Instantiate(interfacePrefab);
        GameObject.DontDestroyOnLoad(_interfaces.gameObject);
    }

    private async void Run()
    {
        await StartGameplay();
    }

    private async UniTask StartGameplay()
    {
        _interfaces.ActiveLoadingScreen(true);

        await LoadScene(Scenes.BOOTSTRAP);
        await LoadScene(Scenes.GAME);

        await UniTask.WaitForSeconds(2);

        var gameplayEntryPoint = GameObject.FindObjectOfType<GameplayEntryPoint>();
        await gameplayEntryPoint.Run();

        _interfaces.ActiveLoadingScreen(false);
    }

    private async UniTask LoadScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
    }
}