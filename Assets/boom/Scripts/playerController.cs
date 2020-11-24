using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 5;
    public   GameObject bullet;

    private float hor, ver;
    private GameObject boom;

   
    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        transform.position += ver * transform.forward * Time.deltaTime * speed;
       // transform.eulerAngles += hor * transform.up * turnSpeed;
        transform.position += hor * transform.right * Time.deltaTime * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatBoom();
        }

    }
    void CreatBoom()
    {
        boom= Instantiate(bullet,transform.position,Quaternion.identity);
        Destroy(boom, 2);
    }

}
