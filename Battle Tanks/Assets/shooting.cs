using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class shooting : NetworkBehaviour
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

            shoot();
            currentTime = 0;
        }
    }
    [Command]
    void CmdAnnounceShoot() {
        GameObject flash = Instantiate(Flash, barrel.position, barrel.rotation);
        NetworkServer.Spawn(flash);
        
        
        GameObject clone = Instantiate(Projectile, barrel.position, barrel.rotation);
        NetworkServer.Spawn(clone);
        RpcaddForce(flash,clone);
        
    }
    [ClientRpc]
    void RpcaddForce(GameObject flash, GameObject clone) {
        flash.GetComponent<ParticleSystem>().Play();
        Destroy(flash, 1.5f);
        clone.layer = gameObject.layer;
        clone.GetComponent<Rigidbody>().AddForce(shootingSpeed * barrel.forward, ForceMode.Impulse);
        Destroy(clone, 3);
        
    }
    [Client]
    public void shoot() {
        if (!isLocalPlayer)
            return;
        CmdAnnounceShoot();

        
    }
}
