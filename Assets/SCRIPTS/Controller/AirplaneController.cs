using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : BaseRigidbodyController
{
    #region Variables
    [Header("Base Airplane Properties")]
    public BaseAirplaneInput input;
    public Transform centerOfGravity;

    [Tooltip("Weight in kg")]
    public float airplaneWeight = 320f;

    [Header("Engines")]
    public List<AirplaneEngine> engines = new List<AirplaneEngine>();

    [Header("Wheels")]
    public List<AirplaneWheel> wheels = new List<AirplaneWheel>();
    #endregion

    #region Methods
    public override void Start()
    {
        base.Start();

        
        rb.mass = airplaneWeight;
        rb.centerOfMass = centerOfGravity.localPosition;

        if (wheels.Count > 0)
        {
            foreach (AirplaneWheel wheel in wheels)
            {
                wheel.InitWheel();
            }
        }
    }

    protected override void HandlePhysics()
    {
        if (input)
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }
    }

    private void HandleAltitude()
    {
        throw new NotImplementedException();
    }

    private void HandleBrakes()
    {
        throw new NotImplementedException();
    }

    private void HandleSteering()
    {
        throw new NotImplementedException();
    }

    private void HandleAerodynamics()
    {
        throw new NotImplementedException();
    }

    private void HandleEngines()
    {
        if (engines.Count > 0)
        {
            foreach (AirplaneEngine engine in engines)
            {
                rb.AddForce(engine.CalculateForce(input.Throttle));
            }
        }
    }
    #endregion
}
