using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelButton : BaseButton
{
    [SerializeField] private float Threshold = 0.1f;
    [SerializeField] private float DeadZone = 0.025f;
    [SerializeField] private string LevelName;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    public override void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    public override void Update()
    {
        if (!isPressed && GetValue() + Threshold >= 1)
        {
            GameScenesControl.Load(LevelName);
        }
    }

    public override float GetValue()
    {
        float value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < DeadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
}
