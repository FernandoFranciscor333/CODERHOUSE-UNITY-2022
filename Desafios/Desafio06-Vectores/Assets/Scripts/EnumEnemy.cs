using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumEnemy : MonoBehaviour
{

    enum EnemyType{Chaser, Camper} 

    [Header("Enemy Behaviour")]
    [SerializeField] EnemyType enemyType;


    [Header("GameObjects")]
    [SerializeField] Transform player;
    [SerializeField] GameObject enemyTurret;
    [SerializeField] GameObject cannonMouth;
    [SerializeField] GameObject projectile;


    [Header("Enemy Parameters")]
    [SerializeField] float tankRotationSpeed = 0.5f;
    [SerializeField] float minDistance = 40f;
    [SerializeField] float chaseDistance = 200f;
    [SerializeField] float camperDistance = 400f;
    [SerializeField] float chasingSpeed = 10f;
    [SerializeField] float shootSpeed = 200f;
    [SerializeField] float coolDown = 10f;       


    private bool canShoot = false;
    private float timePass = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

        switch(enemyType){
            case EnemyType.Chaser:
                RotateToTarget();        
                ChasePlayer(distanceFromPlayer, chaseDistance);
                break;
            case EnemyType.Camper:
                if(distanceFromPlayer <= camperDistance){
                    PointToTarget();
                    Shoot();
                }
                break;
            default:
                Debug.Log("ERROR");
                break;
        }
    }

    public void RotateToTarget(){
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * tankRotationSpeed);
    }

    public void PointToTarget(){        
        Vector3 directionFace = player.position - transform.position;        
        enemyTurret.transform.rotation = Quaternion.LookRotation(directionFace);
    }

    public void ChasePlayer(float distance, float distanceToShoot){
        if(distance >= minDistance){
            transform.Translate(chasingSpeed * Time.deltaTime * Vector3.forward);
        }

        if(distance <= distanceToShoot){
            PointToTarget();
            Shoot();
        }
    }

    public void Shoot(){
        if(canShoot){
            //"crotera" ranges
            float xRandomRotation = Random.Range(-0.5f,2f);
            float yRandomRotation = Random.Range(-5f,5f);

            Quaternion shootAngle = Quaternion.Euler(xRandomRotation, yRandomRotation, 0);
            cannonMouth.transform.localRotation = shootAngle;
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
