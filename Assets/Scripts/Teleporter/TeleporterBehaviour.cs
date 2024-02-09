using UnityEngine;

public class TeleporterBehaviour : MonoBehaviour
{
    [Header("References")]
    public GameObject destination;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = destination.transform.position;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
