using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PLANE_INPUT_AND_PHYSICS : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float forwardSpeed = 10f;

    float mousePosY;
    float midpointHorizontal;
    float directionHorizontal;
    [SerializeField] float horizontalTurningSpeed = 5f; // Pohyb do stran
    float horizontalTurning;

    float mousePosX;
    float midpointVertical;
    float directionVertical;
    [SerializeField] float verticalTurningSpeed = 5f;
    float verticalTurning;

    Vector3 rotateOnAxis;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        midpointHorizontal = Mathf.Lerp(0, Screen.width, 0.5f); // Vrací polovinu šířky obrazovky
        midpointVertical = Mathf.Lerp(0, Screen.height, 0.5f); // Vrací polovinu výšky obrazovky
        Debug.Log("midpointHorizontal:" + midpointHorizontal);
        Debug.Log("midpointVertical:" + midpointVertical);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;


        mousePosY = Input.mousePosition.y;
        mousePosX = Input.mousePosition.x;

        /*
        directionHorizontal = mousePosY - midpointHorizontal;

        if (directionHorizontal > 0)
        {
            directionHorizontal = 1;
        } else if (directionHorizontal < 0)
        {
            directionHorizontal = -1;
        }*/

        directionVertical = mousePosX - midpointVertical;

        /*if (directionVertical > 0)
        {
            directionVertical = 1;
        }
        else if (directionVertical < 0)
        {
            directionVertical = -1;
        }
        

        horizontalTurning = directionHorizontal * horizontalTurningSpeed * Time.deltaTime;
        verticalTurning = directionVertical * verticalTurningSpeed * Time.deltaTime;

        //Debug.Log("Vertical turning is:" + verticalTurning);
        //Debug.Log("Horizontal turning is" + horizontalTurning);

        //Debug.Log("Vertical mouse position is:" + mousePosX);
        //Debug.Log("Horizontal mouse position is:" + mousePosY);

        Debug.Log("Vertical turning is:" + directionVertical);
        Debug.Log("Horizontal turning is" + directionHorizontal);
        */
        rotateOnAxis = new Vector3(verticalTurning, horizontalTurning, 0);
        // Debug.Log("Rotation X, Y ,Z is:" + rotateOnAxis);

        Quaternion.Euler(rotateOnAxis);
    }
}
