using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEngine : MonoBehaviour
{
    #region Variables
    public float maxForce = 200f;
    public float maxRPM = 1200f;
    #endregion

    #region Methods
    public Vector3 CalculateForce(float throttle)
    {
        float finalThrottle = Mathf.Clamp01(throttle);
        float finalPower = finalThrottle * maxForce;

        Vector3 finalForce = transform.forward * finalPower;

        return finalForce;
    }
    #endregion;
}
