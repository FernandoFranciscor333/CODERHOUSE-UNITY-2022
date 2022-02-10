using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject enemyTurret;
    [SerializeField] GameObject cannonMouth;
    [SerializeField] GameObject projectile;


    [Header("Shoot Parameters")]

    [SerializeField] float shootDistance = 400f;
    [SerializeField] float shootSpeed = 200f;
    [SerializeField] float coolDown = 15f;

    private float health = 100;

    private bool canShoot = false;
    private float timePass = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if(shootDistance > distance){
            PointToTarget();
            Shoot();
        }

        if(health <= 0)
            Die();
    }

    public void PointToTarget(){        
        Vector3 directionFace = player.position - transform.position;        
        enemyTurret.transform.rotation = Quaternion.LookRotation(directionFace);
    }

    public void Shoot(){
        if(canShoot){
            //"crotera" ranges
            float xRandomRotation = Random.Range(-0.5f,1.5f);
            float yRandomRotation = Random.Range(-5f,5f);

            Quaternion angle = Quaternion.Euler(xRandomRotation, yRandomRotation, 0);
            cannonMouth.transform.localRotation = angle;
            GameObject createdProjectile = Instantiate(projectile, cannonMouth.transform.position, cannonMouth.transform.rotation);
            createdProjectile.GetComponent<Rigidbody>().velocity = cannonMouth.transform.forward * shootSpeed;
            canShoot = false;
        }

        if(!canShoot)
            timePass += Time.deltaTime;
        
        if(timePass > coolDown){
            timePass = 0;
            canShoot = true;
        }
    }

    private void Die(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="projectile"){
            health -= 50;
        }
    }
}
