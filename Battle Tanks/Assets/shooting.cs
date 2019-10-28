using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject Projectile;
    public Transform barrel;
    public float shootingSpeed;
    public GameObject Flash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject flash = Instantiate(Flash, barrel.position, barrel.rotation);
            flash.GetComponent<ParticleSystem>().Play();
            Destroy(flash, 1.5f);
            GameObject clone = Instantiate(Projectile, barrel.position, barrel.rotation);
            clone.GetComponent<Rigidbody>().AddForce(shootingSpeed * barrel.forward, ForceMode.Impulse);
            Destroy(clone, 3);
           
        }
    }
}
