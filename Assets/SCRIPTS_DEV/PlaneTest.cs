﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTest : MonoBehaviour
{

    private Vector3 target;
    private Rigidbody rb = null;

    public Camera camera = null;
    public float speedMove = 2;
    public float speedRotate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * speedRotate;
        float horizontal = Input.GetAxis("Mouse X") * speedRotate;

        target = new Vector3(transform.position.x, transform.position.y, transform.position.z * 2);


        transform.Translate(0, 0, speedMove * Time.deltaTime);

        if (horizontal > 0)
        {
            transform.Translate(speedMove * Time.deltaTime, 0, 0);
        }
        else if (horizontal < 0)
        {
            transform.Translate(-speedMove * Time.deltaTime, 0, 0);
        }

        if (vertical > 0)
        {
            transform.Translate(0, -speedMove * Time.deltaTime, 0);
        }
        else if (vertical < 0)
        {
            transform.Translate(0, speedMove * Time.deltaTime, 0);
        }

        transform.Rotate(-vertical, horizontal, 0);

    }





}
