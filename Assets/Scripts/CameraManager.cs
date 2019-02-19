using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cameraMain;

    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float rotationSpeed = 10;

    private float horizontalInput, verticalInput, rotationInput;
    


    void Awake ()
    {
        cameraMain = GetComponent<Camera>();
    }

    void Update ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Rotate");

        MoveCamera();
    }

    private void MoveCamera ()
    {
        if (horizontalInput != 0)
        {
            cameraMain.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime, Space.Self);
        }
        if (verticalInput != 0)
        {
            Vector3 tempPosition = transform.position;
            transform.Translate(transform.forward * verticalInput * speed * Time.deltaTime, Space.World);
            transform.position = new Vector3 (transform.position.x, tempPosition.y, transform.position.z);
        }
        if (rotationInput != 0)
        {
            Ray ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0, 0.5f));
            RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
		    	transform.RotateAround(hit.point, Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
			}
        }

    }
}
