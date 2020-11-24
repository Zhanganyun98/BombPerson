using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject boom;
     private  LineRenderer lineRender;
    //public LineRenderer lineRenderer2;
    private void Start()
    {
        lineRender = GetComponent<LineRenderer>();

        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(transform.position.x-1, 0f, 0.0f);
        positions[1] = new Vector3(transform.position.x+1, 0f, 0.0f);
       // positions[2] = new Vector3(2.0f, -2.0f, 0.0f);
        lineRender.positionCount = positions.Length;
        lineRender.SetPositions(positions);

        lineRender.startWidth = 0.5f;
        lineRender.endWidth = 0.5f;
    }

    private void Update()
    {
       // LineRenderer lineRenderer1 = GetComponent<LineRenderer>();

        //lineRenderer1.SetPosition(0, transform.position);
        //lineRenderer1.SetPosition(1, transform.forward);
        //Instantiate(boom);
       
        
    }

}
