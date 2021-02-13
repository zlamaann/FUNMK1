using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEngine : MonoBehaviour
{
    #region Variables
    public float maxForce = 200f;
    public float maxRPM = 1200f;

    public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    #endregion

    #region Methods
    public Vector3 CalculateForce(float throttle)
    {
        float finalThrottle = Mathf.Clamp01(throttle);
        finalThrottle = powerCurve.Evaluate(finalThrottle);

        float finalPower = finalThrottle * maxForce;

        Vector3 finalForce = transform.forward * finalPower;

        return finalForce;
    }
    #endregion;
}
