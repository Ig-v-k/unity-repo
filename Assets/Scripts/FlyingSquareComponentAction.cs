using interfaces;
using UnityEngine;

public class FlyingSquareComponentAction : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float _moveSpeed = 10f;

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
            
            if(Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
        
            if(Input.GetKey(KeyCode.RightArrow))
                transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));        });
    }

    private void action(ActionInterface actionInterface) {
        actionInterface();
    }
}