using UnityEngine;

public class SquareColorCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SquareSpinCollider _squareSpinCollider = other.gameObject.GetComponent<SquareSpinCollider>();
        if (_squareSpinCollider != null)
        {
            if (_squareSpinCollider._compareType == GetComponent<Voyager>()._compareType)
            {
                Debug.Log("!!!COMPARE!!!");
            }
        }
    }
}