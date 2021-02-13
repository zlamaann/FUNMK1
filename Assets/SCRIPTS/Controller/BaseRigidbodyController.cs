using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseRigidbodyController : MonoBehaviour
{
    #region Variables
    protected Rigidbody rb;
    #endregion

    #region Methods
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb) { 
            HandlePhysics();
        }
    }

    protected virtual void HandlePhysics(){}
    #endregion
}
