using System;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    public GameObject _targetGO;
    private TriggerPointModel _triggerPointModel;

    private void Awake()
    {
        _triggerPointModel = new TriggerPointModel();
    }

    private void FixedUpdate() {
        transform.Rotate(0, 0, _triggerPointModel.SpeedRotate);
    }
}