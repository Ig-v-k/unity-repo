using interfaces;
using UnityEngine;

public class VariablesAndFunctions : MonoBehaviour
{
    private int _myInt = 5;

    private void Awake() {
        action(() => {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Awake() --- : " + Time.deltaTime);
        });
    }

    private void Start() {
        action(() => {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Start() --- : " + Time.deltaTime);
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: int -> " + (_myInt *= 3));
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: position.x -> " + transform.position.x);
        });
    }
    
    private void FixedUpdate() {
        action(() => {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- FixedUpdate() --- : " + Time.deltaTime);            
        });
    }

    private void Update() {
        action(() => {
            DebugLogUtil.log(GetType(), "BLOCKER-LOG: --- Update() --- : " + Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.R)) {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.G)) {
                GetComponent<Renderer>().material.color = Color.green;
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                GetComponent<Renderer>().material.color = Color.blue;
            }
        });
    }

    private void action(ActionInterface actionInterface) {
        actionInterface();
    }
}