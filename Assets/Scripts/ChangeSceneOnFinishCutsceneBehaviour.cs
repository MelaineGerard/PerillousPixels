using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnFinishCutsceneBehaviour : MonoBehaviour
{
    [Header("Attributes")]
    public float delay;
    public string sceneName;
    void Update()
    {
        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
