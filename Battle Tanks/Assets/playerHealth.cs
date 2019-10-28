using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float overallHealth;
    private float currentHealth;
    public Rigidbody[] TankParts;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = overallHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float d) {
        currentHealth -= d;
        if (currentHealth < 0) {
            foreach (Rigidbody rb in TankParts) {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.mass = 5;
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.transform.GetComponent<BoxCollider>().enabled = true;
                rb.transform.SetParent(null);
                rb.transform.position += new Vector3(0, 1, 0);
                rb.gameObject.layer = 0;
                Destroy(rb.transform.gameObject,7);

            }
            GetComponent<Rigidbody>().AddExplosionForce(800, transform.position+new Vector3(3, 0,3), 50);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Projectile")) {
            
    
            Damage(collision.gameObject.GetComponent<hit>().damage);
        }
    }
    
}
