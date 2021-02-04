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
    public float airplaneWeight = 600f;

    public List<AirplaneEngine> engines = new List<AirplaneEngine>();
    #endregion

    #region Methods
    public override void Start()
    {
        base.Start();

        rb.mass = airplaneWeight;
        rb.centerOfMass = centerOfGravity.localPosition;
    }

    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleAerodynamics();
        HandleSteering();
        HandleBrakes();
        HandleAltitude();
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

        }
    }
    #endregion
}
