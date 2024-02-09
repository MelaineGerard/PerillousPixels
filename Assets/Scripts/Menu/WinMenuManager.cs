using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
