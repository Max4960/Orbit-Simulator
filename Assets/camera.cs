using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 0.5f;
    public float zoomFactor = 20f;

    void FixedUpdate()
    {
     if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){  // Moves the camera on the x-axis
         transform.position += speed * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
     }
     if (Input.GetAxis("Mouse ScrollWheel") !=0 )
     {
         transform.position += zoomFactor * new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
     }
     if (Input.GetKeyDown("space")){
         avgPositions();
     }
    }

    void avgPositions(){
        List<Vector3> positions = new List<Vector3>();
        body[] bodies = FindObjectsOfType<body>();
        
        for (var i = 0; i < bodies.Length; i++)
        {
            positions.Add (bodies[i].transform.position);
        }

        Vector3 meanVector = Vector3.zero;
    
        foreach(Vector3 pos in positions)
        {
            meanVector += pos;
        }
    
        transform.position = (meanVector / positions.Count);
        transform.position += new Vector3(0,0,-150);
        
    }

    
}
