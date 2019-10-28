using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    public float rotSpeed = 3;
    public bool tp;
    public float slowRot = .3f;
    public Camera kamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tp)
        {
            Vector3 dummy = kamera.transform.forward;
            dummy.y = 0;

            Vector3 destination = Quaternion.AngleAxis(-90, Vector3.up) * dummy;
            transform.forward = Vector3.Lerp(transform.forward, destination, slowRot * Time.deltaTime);
            
        }
        else {
            float h = Input.GetAxis("Mouse X");
            Vector3 rot = new Vector3(0, h, 0);
            rot *= rotSpeed;
            transform.Rotate(rot * Time.deltaTime);
        }
        
    }
}
