using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform PLAYER;

    [SerializeField] private float smoothing = 0.2f;

    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // PŘIDAT - Letadlo přelétá do "view" při startu ve vzduchu (bool)

        // Přidat - Camera funguje až poté co je na správné vzdálenosti od Follow_for_Camera

        // PŘIDAT - Automaticky při startu určit objekt pro pozici PLAYER
    }

    // Update is called once per frame
    void Update()
    {
        // PŘIDAT - Oddalování a přibližování pomocí kolečka myši
        // PŘIDAT - Omezit Přiblížení a oddálení

        // PŘIDAT - Rozhlížení se pomocí držení druhého tlačítka myši

        // PŘIDAT - Rotace kamery dolů při přiblížení

        // Přidat - Zabránit kameře prolétávat objekty.
    }

    // Called after update
    void FixedUpdate()
    {
        Vector3 posBeforeSmoothing = PLAYER.position + offset;
        Vector3 posAfterSmoothing = Vector3.Lerp(transform.position, posBeforeSmoothing, smoothing);
        transform.position = posAfterSmoothing;

        transform.LookAt(PLAYER);
    }
}
