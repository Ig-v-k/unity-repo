using System.Collections.Generic;
using UnityEngine;

public class VariablesAndFunctions : MonoBehaviour {
    private int _myInt = 5;

    private void Start () {
        Action(() => {
            _myInt *= 3;
            Debug.Log("BLOCKER-LOG: int -> " + _myInt);
            Debug.Log("BLOCKER-LOG: position.x -> " + transform.position.x);
        });
    }

    private int MultiplyByTwo(int number) {
        return number * 2;
    }

    private void Action(ActionInterface actionInterface) {
        actionInterface();
    }
}