using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSwitch : MonoBehaviour
{
    public bool fps;
    public playermovement pm;
    public AimPlayer ap;
    public Transform fpsLocation;
    public Transform tpsLocation;
    public CharacterRotation cR;
    public Transform pivotPoint;
    bool movingBack;
    // Start is called before the first frame update
    void Start()
    {
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
                //pm.enabled = false;
                ap.tp = false;
                GetComponent<followPlayer>().enabled = false;
                //cR.enabled = false;
                transform.forward = fpsLocation.right;
                movingBack = false;
            }
            else {
                transform.position = tpsLocation.position;
                transform.SetParent(tpsLocation);
                ap.tp = true;
                pm.enabled = true;
                cR.enabled = true;
                GetComponent<followPlayer>().enabled = true;
                movingBack = true;
            }
        }
        if (movingBack) {
            if (Quaternion.Angle(pivotPoint.localRotation, Quaternion.identity) >= 1)
            {
                pivotPoint.localRotation = Quaternion.Slerp(pivotPoint.localRotation, Quaternion.identity, 1.3f * Time.deltaTime);
            }
            else {
                pivotPoint.localRotation = Quaternion.identity;
                movingBack = false;
            }
        }
         
    }
}
