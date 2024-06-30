using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameEntryPoint
{
    private const string PATH_INTERFACE = "[INTERFACE]";
    private static GameEntryPoint _instance;

    private UIRootView _rootUIView;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutoStart()
    {
#if !UNITY_EDITOR
        Application.targetFrameRate = 60;
#endif

        _instance = new();
        _instance.Run();
        Debug.Log("Autostart");
    }

    public GameEntryPoint()
    {
        var rootUIPrefab = Resources.Load<UIRootView>(PATH_INTERFACE);
        _rootUIView = GameObject.Instantiate(rootUIPrefab);
        GameObject.DontDestroyOnLoad(_rootUIView.gameObject);
    }

    private async void Run()
    {
        await StartGameplay();
    }

    private async UniTask StartGameplay()
    {
        _rootUIView.ActiveLoadingScreen(true);

        await LoadScene(Scenes.BOOTSTRAP);
        await LoadScene(Scenes.GAME);
        await UniTask.WaitForSeconds(2);

        var gameplayEntryPoint = GameObject.FindObjectOfType<GameplayEntryPoint>();
        await gameplayEntryPoint.Run();

        _rootUIView.ActiveLoadingScreen(false);
    }

    private async UniTask LoadScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
    }
}