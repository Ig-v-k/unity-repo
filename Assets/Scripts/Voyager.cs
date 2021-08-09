using UnityEngine;

public class Voyager : MonoBehaviour
{
    public CompareType _compareType;
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                Vector2 _vector2 = new Vector2(transform.position.x, transform.position.y);
                if (_touch.position == _vector2)
                {
                    push();
                }
            }
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            push();
        }
    }

    private void push()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 200);
    }
}