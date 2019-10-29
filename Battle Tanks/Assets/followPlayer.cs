using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 5;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.GetComponent<TeamColor>().isLocalPlayer) {
            player = transform.parent.transform.GetChild(2);
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
