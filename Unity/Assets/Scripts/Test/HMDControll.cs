using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (XRSettings.isDeviceActive == true)
        {
            if (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMDDisplay")
            {
                Debug.Log("Using HMD");
            }
            else
                Debug.Log($"Using {XRSettings.loadedDeviceName}");
        }
        else
            Debug.Log("There is no devise");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
