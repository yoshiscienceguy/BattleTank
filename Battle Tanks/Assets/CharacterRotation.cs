using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public Camera kamera;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v != 0 || h != 0)
        {

            Vector3 fwd = new Vector3(h, 0, v);
            fwd = kamera.transform.TransformDirection(fwd);
            fwd.y = 0;


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fwd), speed * Time.deltaTime);

        }

    }
}
