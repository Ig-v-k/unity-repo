using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

namespace model
{
    public class SquareComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 7f;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));

            if (Input.GetKeyDown(KeyCode.UpArrow))
                _rigidbody2D.AddForce(transform.up * 500f);
        }

        private void FixedUpdate()
        {
            if (transform.position.y < -5f) {
                Destroy(gameObject);
            }
        }
    }
}