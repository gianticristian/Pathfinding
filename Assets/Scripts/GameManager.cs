using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GridManager gridManager = null;
    [SerializeField]
    private CameraManager cameraManager = null;




    void Awake ()
    {
        gridManager.CreateGrid();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {    
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit, 100)) 
            {
                if(hit.collider.tag == "Node") 
                {                         
                    if (!gridManager.Start)
                    {
                        hit.collider.GetComponent<Renderer>().material.color = Color.green;  
                        gridManager.Start = hit.collider.GetComponent<Node>();
                    }
                    else
                    {
                        hit.collider.GetComponent<Renderer>().material.color = Color.red;
                        gridManager.End = hit.collider.GetComponent<Node>();
                        gridManager.CalculateDistance();
                    }
                    

                }
            }    
        }

    }



}
