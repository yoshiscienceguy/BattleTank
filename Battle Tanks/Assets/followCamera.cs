using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform kamera;
    // Start is called before the first frame update
    void Start()
    {
        if (kamera == null)
        {
            kamera = transform.parent.parent.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newThing = kamera.transform.forward;
        newThing.y = 0;
        newThing = Quaternion.AngleAxis(90, Vector3.up) * newThing;
        transform.forward = newThing; 
    }
}
