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
            //cameraMain.transform.Translate(0, 0, verticalInput * speed * Time.deltaTime, Space.World);

            Vector3 temp = transform.position;
            transform.Translate(transform.forward * verticalInput * speed * Time.deltaTime, Space.World);
            transform.position = new Vector3 (transform.position.x, temp.y, transform.position.z);

        }
        if (rotationInput != 0)
        {
            //camera.transform.Translate(Vector3.forward * rotationSpeed * Time.deltaTime);
            //cameraMain.transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);

            
            //Vector3 rotation = transform.eulerAngles;
            //rotation.y += rotationInput * rotationSpeed * Time.deltaTime;
            //transform.eulerAngles = rotation;

            //cameraMain.transform.RotateAround(Vector3.zero, Vector3.up, rotationInput * rotationSpeed * Time.deltaTime); 


            Ray ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0, 0.5f));
            RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
		    	//transform.RotateAround(hit.point, Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
                    print("I'm looking at " + hit.transform.name);
               
			}
            else
                   print("I'm looking at nothing!");
            

        }

    }
}
