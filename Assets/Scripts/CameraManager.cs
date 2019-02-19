using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Camera cameraMain;

    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float rotationSpeed = 10;

    private float moveHorizontal, moveVertical, rotation;
    

    void Awake ()
    {
        cameraMain = Camera.main;
    }

    void Update ()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        MoveCamera();
    }

    private void MoveCamera ()
    {
        if (moveHorizontal != 0)
        {
            cameraMain.transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime, Space.World);
        }
        if (moveVertical != 0)
        {
            cameraMain.transform.Translate(0, 0, moveVertical * speed * Time.deltaTime, Space.World);
        }
        //if (Input.GetAxis("Vertical"))
        //{
        //    camera.transform.Translate(Vector3.forward * rotationSpeed * Time.deltaTime);
        //}

    }
}
