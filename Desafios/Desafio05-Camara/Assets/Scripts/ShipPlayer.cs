using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayer : MonoBehaviour
{

    [Header("Move and Direction Parameters")]
    [SerializeField] private KeyCode speed2Key = KeyCode.W;
    [SerializeField] private KeyCode speed3Key = KeyCode.LeftShift;
    [SerializeField] private KeyCode slowDownKey = KeyCode.S;
    [SerializeField] private float shipSpeedSlowDown = 0.5f;
    [SerializeField] private float shipSpeedx1 = 1f;
    [SerializeField] private float shipSpeedx2 = 2f;
    [SerializeField] private float shipSpeedx3 = 4f;
    [SerializeField] private float rotateSpeed = 6f;

    [Header("Shooting Parameters")]
    [SerializeField] private KeyCode leftShoot = KeyCode.Q;
    [SerializeField] private KeyCode rightShoot = KeyCode.E;
    [SerializeField] private GameObject[] leftCannons;
    [SerializeField] private GameObject[] rightCannons;    
    [SerializeField] private GameObject Proyectile;    
    [SerializeField] private float coolDown=1f;
    [SerializeField] private float shootSpeed = 50f;

    private bool canShoot = true;
    private float timePass = 0;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(speed2Key)){
            MoveShip(shipSpeedx2);            
        }else if(Input.GetKey(speed3Key)){
            MoveShip(shipSpeedx3);            
        }else if(Input.GetKey(slowDownKey)){
            MoveShip(shipSpeedSlowDown);            
        } else {
            MoveShip(shipSpeedx1);            
        }
        
    }

    void LateUpdate() {
        RotateShip();
        Shoot();
    }

    private void MoveShip(float speed){       
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void RotateShip(){
        float axis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, axis * rotateSpeed * Time.deltaTime);
    }

    private void Shoot(){
        if(Input.GetKeyDown(leftShoot) && canShoot){
            GameObject createdCannonball_L1 = Instantiate(Proyectile, leftCannons[0].transform.position, Proyectile.transform.rotation);
            createdCannonball_L1.GetComponent<Rigidbody>().velocity = leftCannons[0].transform.up * shootSpeed;
            GameObject createdCannonball_L2 = Instantiate(Proyectile, leftCannons[1].transform.position, Proyectile.transform.rotation);
            createdCannonball_L2.GetComponent<Rigidbody>().velocity = leftCannons[1].transform.up * shootSpeed;
            GameObject createdCannonball_L3 = Instantiate(Proyectile, leftCannons[2].transform.position, Proyectile.transform.rotation);
            createdCannonball_L3.GetComponent<Rigidbody>().velocity = leftCannons[2].transform.up * shootSpeed;
            GameObject createdCannonball_L4 = Instantiate(Proyectile, leftCannons[3].transform.position, Proyectile.transform.rotation);
            createdCannonball_L4.GetComponent<Rigidbody>().velocity = leftCannons[3].transform.up * shootSpeed;
            canShoot = false;
        }

        if(Input.GetKeyDown(rightShoot) && canShoot){
            GameObject createdCannonball_R1 = Instantiate(Proyectile, rightCannons[0].transform.position, Proyectile.transform.rotation);
            createdCannonball_R1.GetComponent<Rigidbody>().velocity = rightCannons[0].transform.up * shootSpeed;
            GameObject createdCannonball_R2 = Instantiate(Proyectile, rightCannons[1].transform.position, Proyectile.transform.rotation);
            createdCannonball_R2.GetComponent<Rigidbody>().velocity = rightCannons[1].transform.up * shootSpeed;
            GameObject createdCannonball_R3 = Instantiate(Proyectile, rightCannons[2].transform.position, Proyectile.transform.rotation);
            createdCannonball_R3.GetComponent<Rigidbody>().velocity = rightCannons[2].transform.up * shootSpeed;
            GameObject createdCannonball_R4 = Instantiate(Proyectile, rightCannons[3].transform.position, Proyectile.transform.rotation);
            createdCannonball_R4.GetComponent<Rigidbody>().velocity = rightCannons[3].transform.up * shootSpeed;
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
