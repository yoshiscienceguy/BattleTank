using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    Camera camera;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v > 0)
        {
            Vector3 fwd;
            if (h == 0 && v != 0)
            {
                if (v < 0)
                {

                    h = 0;
                    fwd = new Vector3(h, 0, v);
                    fwd = camera.transform.TransformDirection(fwd);
                }
                else
                {
                    fwd = camera.transform.forward;
                }
            }
            else
            {
                
                fwd = new Vector3(h, 0, v);
                if (v < 0) {
                    fwd.z = 0;
                }
                Debug.Log(fwd);
                fwd = camera.transform.TransformDirection(fwd);


            }
            fwd.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fwd), speed * Time.deltaTime);
        }
    }
}
