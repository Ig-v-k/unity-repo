using UnityEngine;

public class FlySquarePoint : MonoBehaviour
{
    public GameObject[] _flyElement;

    private void Start()
    {
        SpawnElem();
    }
    
    private void SpawnElem()
    {
        Instantiate(_flyElement[Random.Range(0,_flyElement.Length)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}