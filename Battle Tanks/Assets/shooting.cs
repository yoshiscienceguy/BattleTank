using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject Projectile;
    public Transform barrel;
    public float shootingSpeed;
    public GameObject Flash;
    public float frequency = 1f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < frequency) {
            currentTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && currentTime >= frequency) {
            GameObject flash = Instantiate(Flash, barrel.position, barrel.rotation);
            flash.GetComponent<ParticleSystem>().Play();
            Destroy(flash, 1.5f);
            GameObject clone = Instantiate(Projectile, barrel.position, barrel.rotation);
            clone.layer = gameObject.layer;
            clone.GetComponent<Rigidbody>().AddForce(shootingSpeed * barrel.forward, ForceMode.Impulse);
            Destroy(clone, 3);
            currentTime = 0;
           
        }
    }
}
