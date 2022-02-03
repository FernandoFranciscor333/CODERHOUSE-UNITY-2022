using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Movement")]    
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float xLimit = 15f;
    [SerializeField] private float zLimit = 7f;


    [Header("Shoot parameters")]
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject proyectile;
    [SerializeField] KeyCode defaultShootKey = KeyCode.Mouse0;
    [SerializeField] float coolDown = 2f;

    

    private bool canMove = true;
    private bool canShoot = true;
    private float timePass;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Shoot();

    }

    public void HandleInput(){
        if (Input.GetKey(KeyCode.W))
            Move(Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            Move(Vector3.left);

        if (Input.GetKey(KeyCode.S))
            Move(Vector3.back);
        
        if (Input.GetKey(KeyCode.D))
            Move(Vector3.right);
    }

    public void Move(Vector3 direction){
        if(canMove){
            if(transform.position.x > xLimit || transform.position.x < -xLimit ||
                transform.position.z > zLimit || transform.position.z < -zLimit){                    
                    transform.position = new Vector3(0,21.13f,0);
                } else {
                    transform.Translate(walkSpeed * Time.deltaTime * direction);
                }
        }            
    }

    public void Shoot(){
        if(Input.GetKeyDown(defaultShootKey) && canShoot){
            Instantiate(proyectile, spawner.transform.position, proyectile.transform.rotation);
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
