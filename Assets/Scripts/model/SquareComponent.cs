using UnityEngine;

namespace model
{
    public class SquareComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 7f;

        public float moveSpeed => _moveSpeed;
    }
}