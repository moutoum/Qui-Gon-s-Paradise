using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startSceneName;
    
    public void Play()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
