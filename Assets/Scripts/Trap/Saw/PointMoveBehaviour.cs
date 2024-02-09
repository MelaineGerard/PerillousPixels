using UnityEngine;

namespace Trap.Saw
{
    public class PointMoveBehaviour : MonoBehaviour
    {
        [Header("References")]
        public GameObject[] waypoints;
        public SpriteRenderer spriteRenderer;
        
        [Header("Attributes")]
        public float speed = 0.5f;
        public float distanceToWaypoint = 0.1f;
        
        private bool _reverse;
        private int _currentWaypointIndex;
        
        void Start()
        {
            if (waypoints.Length == 0)
            {
                // On désactive le script si il n'y a pas de waypoints
                Destroy(this);
                return;
            }
            
            _currentWaypointIndex = 0;
            _reverse = false;
            
            MoveToNextWaypoint();
        }
        
        void Update()
        {
            // On vérifie si on est arrivé au waypoint
            if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].transform.position) < distanceToWaypoint)
            {
                MoveToNextWaypoint();
            }
            else
            {
                // On se déplace vers le waypoint
                MoveToPoint();
            }
        
        }
        
        private void MoveToNextWaypoint()
        {
            if (_reverse)
            {
                ReversedMoveToNextWaypoint();
                
                return;
            }
            
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = waypoints.Length - 1;
                _reverse = true;
                
                ReversedMoveToNextWaypoint();
            }
        }

        private void MoveToPoint()
        {
            var position = transform.position;
            Vector3 direction = waypoints[_currentWaypointIndex].transform.position - position;
            direction.Normalize();
            position += direction * (speed * Time.deltaTime);
            transform.position = position;
            
            // On flipX le sprite si on va vers la gauche
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

        private void ReversedMoveToNextWaypoint()
        {
            _currentWaypointIndex--;
            
            if (_currentWaypointIndex < 0)
            {
                _currentWaypointIndex = 0;
                _reverse = false;
                
                MoveToNextWaypoint();
            }
        }
    }
}
