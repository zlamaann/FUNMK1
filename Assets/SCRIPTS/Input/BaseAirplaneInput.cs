using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAirplaneInput : MonoBehaviour
{
    #region Variables
    protected float pitch = 0f;
    protected float roll = 0f;
    protected float yaw = 0f;
    protected float throttle = 0f;
    protected int flaps = 0;
    protected float brake = 0f;
    #endregion

    #region Properties
    public float Pitch 
    {
        get { return pitch; }
    }
    protected float Roll
    {
        get { return roll; }
    }
    protected float Yaw
    {
        get { return yaw; }
    }
    protected float Throttle
    {
        get { return throttle; }
    }
    protected int Flaps
    {
        get { return flaps; }
    }
    protected float Brake
    {
        get { return brake; }
    }
    #endregion


    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        //Process main control inputs
        pitch = Input.GetAxis("Pitch");
        roll = Input.GetAxis("Roll");
        yaw = Input.GetAxis("Yaw");
        throttle = Input.GetAxis("Throttle");

        //Process brake input
        brake = Input.GetKey(KeyCode.Space) ? 1f : 0f;

        //Process flaps inputs
        if (Input.GetKeyDown(KeyCode.W))
        {
            flaps += 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            flaps -= 1;
        }

        flaps = Mathf.Clamp(flaps, 0, 3);

    }
    #endregion
}
