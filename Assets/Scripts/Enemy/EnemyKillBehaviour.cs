using UnityEngine;

public class EnemyKillBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // On récupère le parent du gameObject
            var parent = gameObject.transform.parent;
            if (parent != null)
            {
                // On récupère le parent du parent
                var grandParent = parent.parent;
                if (grandParent != null)
                {
                    Destroy(grandParent.gameObject);
                }
                else
                {
                    Destroy(parent.gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}