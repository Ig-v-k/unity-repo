using System;
using interfaces;
using model;
using UnityEngine;

public class MainSquareComponentAction : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SquareComponent _squareComponent;

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

            if(Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(Vector3.left * (_squareComponent.moveSpeed * Time.deltaTime));
        
            if(Input.GetKey(KeyCode.RightArrow))
                transform.Translate(Vector3.right * (_squareComponent.moveSpeed * Time.deltaTime));
        
            if(Input.GetKeyDown(KeyCode.UpArrow))
                _rigidbody2D.AddForce(transform.up * 500f);

            if (transform.position.y < -4f)
            {
                Destroy(gameObject);
            }
        });
    }

    private void action(ActionInterface actionInterface) {
        actionInterface();
    }
}