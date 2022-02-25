using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Basket : MonoBehaviour
{
    private List<BaseItem> Items = new List<BaseItem>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Items.Add(other.gameObject.GetComponent<BaseItem>());
            Debug.Log($"Stored {other.gameObject.tag} - {other.gameObject.name}");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Items.Remove(other.gameObject.GetComponent<BaseItem>());
            Debug.Log($"Removed {other.gameObject.tag} - {other.gameObject.name}");
        }
    }
}
