using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenuBehaviour : MonoBehaviour
    {
        [Header("References")]
        public GameObject aboutPanel;
    
        [Header("Attributes")]
        public string gameSceneName;
    
        public void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void ShowAbout()
        {
            aboutPanel.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
        public void CloseAbout()
        {
            aboutPanel.SetActive(false);
        }
    }
}
