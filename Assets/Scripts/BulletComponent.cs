using System;
using interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace model
{
    public class BulletComponent : MonoBehaviour
    {

        private GameObject _displayCounterTextGO;
        private GameObject _triggerComponentCircle;

        private void Awake()
        {
            _triggerComponentCircle = GameObject.Find("TriggerComponentCircle");
            _displayCounterTextGO = GameObject.Find("TriggerText");
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == _triggerComponentCircle)
            {
                GetComponent<Renderer>().material.color = Color.red;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                _displayCounterTextGO.GetComponent<DisplayCounterText>().increment();
            }
        }
    }
}