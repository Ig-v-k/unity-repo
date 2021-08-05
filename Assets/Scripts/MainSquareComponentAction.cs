using interfaces;
using model;
using UnityEngine;

public class MainSquareComponentAction : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public Transform _barrel;
    public Rigidbody2D _bulletComponent;
    private SquareComponent _squareComponent;

    private int _bullets = 10;

    private void Awake()
    {
        action(() => { DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Awake() --- : " + Time.deltaTime); });
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _squareComponent = GetComponent<SquareComponent>();
    }

    private void Start()
    {
        action(() =>
        {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Start() --- : " + Time.deltaTime);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: position.x -> " + transform.position.x);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: activeSelf -> " + gameObject.activeSelf);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: activeInHierarchy -> " + gameObject.activeInHierarchy);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: _rigidbody2DBulletPrefab -> " + _bulletComponent.name);
        });
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

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(Vector3.left * (_squareComponent.moveSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.RightArrow))
                transform.position += new Vector3(_squareComponent.moveSpeed * Time.deltaTime, 0.0f, 0.0f);

            if (Input.GetKeyDown(KeyCode.UpArrow))
                _rigidbody2D.AddForce(transform.up * 500f);

            if (Input.GetKeyDown(KeyCode.Space) && _bullets > 0) {
                Rigidbody2D _rigidbody2DBullet = Instantiate(_bulletComponent, _barrel.position, _barrel.rotation);
                _rigidbody2DBullet.AddForce(_barrel.up * 400);
                _bullets--;
            }

            if (transform.position.y < -5f) {
                Destroy(gameObject);
            }
        });
    }

    private void action(ActionInterface actionInterface)
    {
        actionInterface();
    }
}