using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public float speed = 2;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Input.mousePosition, speed * Time.deltaTime);
    }
}
