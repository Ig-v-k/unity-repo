using System;
using UnityEngine;

public class FlySquarePoint : MonoBehaviour
{
    public GameObject _flyElement;

    private void Start()
    {
        SpawnElem();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnElem();
        }
    }

    private void SpawnElem()
    {
        Instantiate(_flyElement, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}