using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public string namePlayer = "Coso";
    [SerializeField] public float speedPlayer = 2f;

    [Header("Initial player Size (Set before play)")]
    [SerializeField] public float PlayerSize = 1f;

    [Header("Movements (one at once)")]
    [SerializeField] public bool turnRight;
    [SerializeField] public bool turnBack;
    private bool canMove = true;

    void Start()
    {
        transform.localScale = new Vector3(PlayerSize,PlayerSize,PlayerSize);
        transform.position -= new Vector3(0,0.5f,0);
    }

    void Update()
    {
        if(canMove)
            ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (turnRight == true && turnBack == false){
            transform.position += Vector3.right * speedPlayer * Time.deltaTime;
            turnBack = false;
        }else if (turnBack == true && turnRight == false){
            transform.position += Vector3.back * speedPlayer * Time.deltaTime;
            turnRight = false;
        }else{
            transform.position += Vector3.forward * speedPlayer * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "BlueZone"){
            canMove = false;
            transform.localScale = new Vector3(2,2,2);
        }
    }
}
