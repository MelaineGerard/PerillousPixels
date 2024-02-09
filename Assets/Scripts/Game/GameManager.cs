using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        public Image healthImage;
        public TMP_Text fruitsText;
        public int totalFruits;
        public int collectedFruits;
    
    
        public static GameManager Instance;

    
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
            
            collectedFruits = 0;
            totalFruits = 0;
            
            UpdateFruitsText();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        public void UpdateHealth(float health, float maxHealth)
        {
            healthImage.fillAmount = GetRatio(health, maxHealth);

            UpdateColor(GetRatio(health, maxHealth));

            if (health <= 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }

        private void Win()
        {
            SceneManager.LoadScene("WinScene");
        }

        private float GetRatio(float health, float maxHealth)
        {
            return health / maxHealth;
        }

        private void UpdateColor(float healthPercentage)
        {
            healthImage.color = healthPercentage switch
            {
                > 0.75f => Color.green,
                > 0.5f => Color.yellow,
                > 0.25f => new Color(1, 0.5f, 0),
                _ => Color.red
            };
        }

        public void AddFruits(int fruitsToAdd = 1)
        {
            totalFruits += fruitsToAdd;
        
            UpdateFruitsText();
        }
    
        public void CollectFruits(int collectedFruitsToAdd)
        {
            collectedFruits += collectedFruitsToAdd;
        
            UpdateFruitsText();
            
            if (collectedFruits == totalFruits)
            {
                Win();
            }
        }

        private void UpdateFruitsText()
        {
            fruitsText.text = $"{collectedFruits}/{totalFruits}";
        }
    }
}
