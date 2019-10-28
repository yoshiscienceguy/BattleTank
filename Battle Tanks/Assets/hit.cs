using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject smoke;
    public float damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Transform child in transform) {
            child.SetParent(null);
            Destroy(child.gameObject, 3);
        }
        GameObject clone = Instantiate(Explosion, transform.position, Quaternion.identity);
        GameObject clone2 = Instantiate(smoke, transform.position, Quaternion.identity);
        Destroy(clone2, 7);
        Destroy(clone, 4);
        Destroy(gameObject);
    }
}
