using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] public int _speedRotateElements = 3;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -_speedRotateElements);
    }
}