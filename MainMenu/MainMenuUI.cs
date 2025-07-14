using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string singlePlayerScene = "SinglePlayerScene";
    public string multiplayerScene = "MultiplayerScene";

    public void OnSinglePlayerPressed()
    {
        LoadScene(singlePlayerScene);
    }

    public void OnMultiplayerPressed()
    {
        LoadScene(multiplayerScene);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
