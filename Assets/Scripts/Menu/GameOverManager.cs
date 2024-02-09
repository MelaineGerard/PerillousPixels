using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameOverManager : MonoBehaviour
    {
        public void Retry()
        {
            SceneManager.LoadScene("GameScene");
        }
    
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
