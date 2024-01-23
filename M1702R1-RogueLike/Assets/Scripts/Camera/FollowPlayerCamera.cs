using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{

        [SerializeField] private Vector3 offset;
        [SerializeField] private float damping;

        public GameObject target;

        private Vector3 vel = Vector3.zero;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        private void FixedUpdate()
        {

            Vector3 targetPosition = target.transform.position + offset;
            targetPosition.z = transform.position.z;
           


            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
        }
  
}
