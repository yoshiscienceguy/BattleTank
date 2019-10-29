using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class followPlayer : NetworkBehaviour
{
    public Transform player;
    public float speed = 5;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer) {
            player = transform.parent.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        transform.position = player.position + offset;
        //transform.RotateAround(player.position, Vector3.left, Input.GetAxis("Mouse Y") * speed);
        Vector3 rotations = transform.localEulerAngles;
        rotations.z = 0;
        transform.localEulerAngles = rotations;
        transform.LookAt(player.position);
    }
}
