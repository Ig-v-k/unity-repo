using interfaces;
using UnityEngine;

public class FlyingSquareComponentAction : MonoBehaviour
{
    [SerializeField] private int _myInt = 5;
    [SerializeField] private Light _light;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSpeed = 50f;

    private void Awake()
    {
        action(() => { DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Awake() --- : " + Time.deltaTime); });
    }

    private void Start()
    {
        action(() =>
        {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Start() --- : " + Time.deltaTime);
            _light = GetComponent<Light>();
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: int -> " + (_myInt *= 3));
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: position.x -> " + transform.position.x);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: activeSelf -> " + gameObject.activeSelf);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: activeInHierarchy -> " + gameObject.activeInHierarchy);
        });
    }

    private void Update()
    {
        action(() =>
        {
            if (Input.GetKeyDown(KeyCode.R))
                GetComponent<Renderer>().material.color = Color.red;
            
            if (Input.GetKeyDown(KeyCode.G))
                GetComponent<Renderer>().material.color = Color.green;
            
            if (Input.GetKeyDown(KeyCode.B))
                GetComponent<Renderer>().material.color = Color.blue;
            
            if (Input.GetKeyUp(KeyCode.Space))
                _light.enabled = !_light.enabled;
        });
        action(() =>
        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(-Vector3.forward * (moveSpeed * Time.deltaTime));

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        });
    }

    private void action(ActionInterface actionInterface)
    {
        actionInterface();
    }
}