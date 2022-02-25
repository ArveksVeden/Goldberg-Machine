using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Flag : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand" && gameObject.tag == "StartFlag")
            GlobalEvents.StartFlagTouched.Invoke();

        if (collision.gameObject.tag == "Item" && gameObject.tag == "EndFlag")
            GlobalEvents.EndFlagTouched.Invoke();
    }
}
