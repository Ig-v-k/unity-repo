using System;
using UnityEngine;
using UnityEngine.UI;

public class VirtualDPad : MonoBehaviour {
    public Text _phaseDisplayText;
    private Touch _touch;
    private Vector2 _touchStartPosition, _touchEndPosition;
    private string _direction;

    private void Update() {
        if (Input.touchCount > 0) {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began) {
                _touchStartPosition = _touch.position;
            } else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Moved) {
                _touchEndPosition = _touch.position;

                float x = _touchEndPosition.x - _touchStartPosition.x;
                float y = _touchEndPosition.y - _touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0) {
                    _direction = "Tap";
                } else if (Mathf.Abs(x) > Mathf.Abs(y)) {
                    _direction = (x > 0) ? "Right" : "Left";
                } else {
                    _direction = (y > 0) ? "Up" : "Down";
                }
            } else if (_touch.phase == TouchPhase.Stationary) {
                _direction = "Retention";
            }
        }
        
        _phaseDisplayText.text = _direction;
    }
}