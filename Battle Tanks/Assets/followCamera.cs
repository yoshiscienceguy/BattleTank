using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newThing = camera.transform.forward;
        newThing.y = 0;
        newThing = Quaternion.AngleAxis(90, Vector3.up) * newThing;
        transform.forward = newThing; 
    }
}
