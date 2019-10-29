using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSwitch : MonoBehaviour
{
    public bool fps;

    [HideInInspector]
    public AimPlayer ap;
    [HideInInspector]
    public Transform fpsLocation;
    [HideInInspector]
    public Transform tpsLocation;

    [HideInInspector]
    public Transform pivotPoint;

    // Start is called before the first frame update
    void Start()
    {
        if(ap)
            ap.tp = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            fps = !fps;
            if (fps)
            {
        
                transform.position = fpsLocation.position;
                transform.SetParent(fpsLocation);
              
                ap.tp = false;
                GetComponent<followPlayer>().enabled = false;
         
                transform.forward = fpsLocation.right;
                
            }
            else {
                transform.position = tpsLocation.position;
                transform.SetParent(tpsLocation);
                ap.tp = true;
                GetComponent<followPlayer>().enabled = true;
               
            }
        }
         
    }
}
