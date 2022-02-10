using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject enemyTurret;
    [SerializeField] GameObject cannonMouth;
    [SerializeField] GameObject projectile;
    [SerializeField] float tankRotationSpeed = 0.5f;


    [Header("Chasing Parameters")]
    [SerializeField] float minDistance = 40f;
    [SerializeField] float chaseDistance = 200f;
    [SerializeField] float chasingSpeed = 10f;
    [SerializeField] float shootSpeed = 200f;
    [SerializeField] float coolDown = 5f;    


    private bool canShoot = false;
    private float timePass = 0;

    void Start()
    {
        
    }

    void Update()
    {
        RotateToTarget();        
        ChasePlayer();

    }

    public void RotateToTarget(){
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * tankRotationSpeed);
    }

    public void PointToTarget(){        
        Vector3 directionFace = player.position - transform.position;        
        enemyTurret.transform.rotation = Quaternion.LookRotation(directionFace);
    }

    public void ChasePlayer(){
        float distance = Vector3.Distance(player.position, transform.position);        

        if(distance <= chaseDistance){             
            PointToTarget();
            Shoot();
        }

        if(distance >= minDistance){
            transform.Translate(chasingSpeed * Time.deltaTime * Vector3.forward);
        }
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
}
