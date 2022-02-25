using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent StartFlagTouched = new UnityEvent();
    public static UnityEvent EndFlagTouched = new UnityEvent();
}
