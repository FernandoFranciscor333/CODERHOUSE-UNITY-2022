using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Parameters")] 
    [SerializeField] private int health = 100;
    [Header("Movement")] 
    [SerializeField] private float playerSpeed = 2f;
    [SerializeField] [Range(-1,1)] private float Xmovement = 0f;
    [SerializeField] [Range(-1,1)] private float Zmovement = 0f;
    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEALTH: "+ health);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            ApllyMovement();

        if(health <= 0)
            Death();
    }

    //METHODS
    public void ApllyMovement(){
        transform.Translate(playerSpeed * new Vector3(Xmovement,0,Zmovement) * Time.deltaTime);
    }

    public void TakeDamage(){
        health -= 50;
        Debug.Log("HEALTH: "+ health);
    }

    public void Heal(){
        if (health < 100)
            health += 50;
        Debug.Log("HEALTH: "+ health);
    }

    public void Death(){
            canMove = false;
            Debug.Log("GAME OVER");
    }

    //TRIGGER
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Fire")
            TakeDamage();

        if(other.tag == "HealZone")
            Heal(); 

        if(other.tag == "GoalZone"){
            canMove = false;
            transform.localScale = new Vector3(2,2,2);
            Debug.Log("YOU WIN!!!");
        }
    }
}
