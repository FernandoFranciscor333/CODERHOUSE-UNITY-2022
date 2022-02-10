using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float speed = 30f;
    [SerializeField] float rotateSpeed =5;
    [SerializeField] float turretMovementSpeed = 5f;
    [SerializeField] float cannonMovementSpeed = 0.5f;
    [SerializeField] float upperPointLimit = 10f;
    [SerializeField] float lowerPointLimit = -10f;


    [Header("Shoot Parameters")]
    [SerializeField] KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] KeyCode altShootKey = KeyCode.Space;
    [SerializeField] float shootSpeed = 50f;
    [SerializeField] float coolDown = 2f;


    [Header("Object references")]
    [SerializeField] GameObject turret;
    [SerializeField] GameObject cannon;
    [SerializeField] GameObject cannonMouth;
    [SerializeField] GameObject projectile;

    private Vector2 currentInput;
    private Vector3 moveDirection;
    private CharacterController characterController;
    private float xTurretAxis;
    private float xCannonRotation;
    private bool canShoot = true;
    private float timePass = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
        RotateTank();
        TurretMovement();
        CannonMovement();
        Shoot();
    }

    void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveTank(){
        currentInput = new Vector2(0, speed * Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(Vector3.forward)*currentInput.y;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void RotateTank(){
        float axis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, axis * rotateSpeed * Time.deltaTime);
    }

    public void TurretMovement(){
        xTurretAxis += Input.GetAxis("Mouse X") * turretMovementSpeed;
        Quaternion angle = Quaternion.Euler(0,xTurretAxis,0);
        turret.transform.localRotation = angle;
    }

    public void CannonMovement(){
        xCannonRotation -= Input.GetAxis("Mouse Y") * cannonMovementSpeed;
        xCannonRotation = Mathf.Clamp(xCannonRotation, lowerPointLimit, upperPointLimit);        
        Quaternion angle = Quaternion.Euler(xCannonRotation, 0, 0);
        cannon.transform.localRotation = angle;
    }

    public void Shoot(){
        if((Input.GetKeyDown(shootKey) || Input.GetKeyDown(altShootKey))  && canShoot){
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
