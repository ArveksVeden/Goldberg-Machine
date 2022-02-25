using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] private float Threshold = 0.1f;
    [SerializeField] private float DeadZone = 0.025f;

    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    public virtual void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    public virtual void Update()
    {
        if (!isPressed && GetValue() + Threshold >= 1)
        {
            Pressed();
        }

        if (isPressed && GetValue() - Threshold <= 0)
        {
            Released();
        }
    }

    public virtual float GetValue()
    {
        float value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < DeadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    public virtual void Pressed()
    {
        isPressed = true;
        OnPressed.Invoke();
    }

    public virtual void Released()
    {
        isPressed = false;
        OnReleased.Invoke();
    }
}
