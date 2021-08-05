using UnityEngine;

namespace model
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 700;

        public float moveSpeed => _moveSpeed;
        
        public void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject == GameObject.Find("TriggerComponentCircle")) {
                GetComponent<Renderer>().material.color = Color.red;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
}