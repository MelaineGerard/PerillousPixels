using UnityEngine;

public class HtpPanelBehaviour : MonoBehaviour
{
    [Header("References")]
    public GameObject panel;
    
    
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    
    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
