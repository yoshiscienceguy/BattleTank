using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float Xspeed = 10;
    public float Yspeed = 3;
    public float gravity = 20;
    Vector3 Direction;
    Rigidbody rb;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        RaycastHit hit;

        if (Physics.Raycast(transform.position,-transform.up,out hit, 15f))
        {
            Direction = new Vector3(h*Yspeed, 0, v*Xspeed);
            if (v < 0)
            {
                Direction.x = 0;
                Direction = transform.GetChild(0).transform.TransformDirection(Direction);
                
            }
            else {
                Direction = camera.transform.TransformDirection(Direction);
            }
            
            Direction.y = 0;
        }

        
        //Direction.y -= gravity * Time.deltaTime;

        rb.AddForce(Direction * 10);

        
    }
}
