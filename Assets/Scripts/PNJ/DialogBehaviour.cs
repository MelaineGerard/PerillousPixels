using TMPro;
using UnityEngine;

namespace PNJ
{
    public class DialogBehaviour : MonoBehaviour
    {
        [Header("References")]
        public GameObject dialogPanel;
        public TMP_Text pnjNameText;
        public TMP_Text dialogText;
    
    
        [Header("Attributes")]
        public string text;
        public string pnjName;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                dialogPanel.SetActive(true);
                pnjNameText.text = pnjName;
                dialogText.text = text;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                dialogPanel.SetActive(false);
            }
        }
    }
}
