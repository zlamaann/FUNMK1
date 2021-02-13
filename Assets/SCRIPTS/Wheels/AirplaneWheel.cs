using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class AirplaneWheel : MonoBehaviour
{

    #region Variables
    private WheelCollider WheelCollider;
    #endregion

    #region Methods
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    public void InitWheel()
    {
        if (WheelCollider)
        {
            WheelCollider.motorTorque = 0.0000000000001f;
        }
    }
    #endregion
}
