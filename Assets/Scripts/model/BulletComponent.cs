using UnityEngine;

namespace model
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5000f;
        
        public float moveSpeed => _moveSpeed;
    }
}