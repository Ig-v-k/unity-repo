using interfaces;
using model;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainSquareComponentAction : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public Transform _barrel;
    public GameObject _bulletComponent;
    private SquareComponent _squareComponent;

    [SerializeField] private int _bullets = 10;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _squareComponent = GetComponent<SquareComponent>();
    }

    private void Update()
    {
        action(() => {
            if (Input.GetKeyDown(KeyCode.R))
                GetComponent<Renderer>().material.color = Color.red;

            if (Input.GetKeyDown(KeyCode.G))
                GetComponent<Renderer>().material.color = Color.green;

            if (Input.GetKeyDown(KeyCode.B))
                GetComponent<Renderer>().material.color = Color.blue;

            if (Input.GetKeyDown(KeyCode.Space) && _bullets > 0) {
                Rigidbody2D _rigidbody2DBullet = Instantiate(_bulletComponent.GetComponent<Rigidbody2D>(), _barrel.position, _barrel.rotation);
                _rigidbody2DBullet.AddForce(_barrel.up * 400);
                _bullets--;
            }
        });
    }

    private void action(ActionInterface actionInterface)
    {
        actionInterface();
    }
}