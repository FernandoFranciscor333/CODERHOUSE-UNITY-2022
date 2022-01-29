using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [Header("WaterGun Movement")]    
    [SerializeField] private float walkSpeed = 8f;

    [Header("Shoot parameters")]
    [SerializeField] GameObject spawner01;
    [SerializeField] GameObject spawner02;
    [SerializeField] GameObject spawner03;
    [SerializeField] GameObject spawner04;
    [SerializeField] GameObject proyectile;

    [Header("Input parameters")]
    [SerializeField] KeyCode defaultShootKey = KeyCode.Mouse0;
    [SerializeField] KeyCode doubleShootKey = KeyCode.J;
    [SerializeField] KeyCode tripleShootKey = KeyCode.K;
    [SerializeField] KeyCode quadrupleShootKey = KeyCode.L;

    private Vector2 currentInput;
    private Vector3 moveDirection;
    private CharacterController characterController;

    void Update()
    {
        Move();
        Shoot();
    }

    void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(){
        currentInput = new Vector2(walkSpeed * Input.GetAxis("Horizontal"),0);
        moveDirection = transform.TransformDirection(Vector3.right)*currentInput.x;
        characterController.Move(moveDirection * Time.deltaTime);
    }

        public void Shoot(){
            if(Input.GetKeyDown(defaultShootKey)){
                Instantiate(proyectile, spawner01.transform);
            } else if (Input.GetKeyDown(doubleShootKey)){
                Instantiate(proyectile, spawner01.transform);
                Instantiate(proyectile, spawner02.transform);
            } else if (Input.GetKeyDown(tripleShootKey)){
                Instantiate(proyectile, spawner01.transform);
                Instantiate(proyectile, spawner02.transform);
                Instantiate(proyectile, spawner03.transform);
            } else if (Input.GetKeyDown(quadrupleShootKey)){
                Instantiate(proyectile, spawner01.transform);
                Instantiate(proyectile, spawner02.transform);
                Instantiate(proyectile, spawner03.transform);
                Instantiate(proyectile, spawner04.transform);
            }
    }
}
