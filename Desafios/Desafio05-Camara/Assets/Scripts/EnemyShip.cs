using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float shipSpeed = 2f;
    [SerializeField] private int health = 100;
    [SerializeField] GameObject mesh;
    [SerializeField] private float destroyTimer = 10f;
    [SerializeField] private float zLimit = -90f;
    private float timePass = 0;
    private bool canMove = true;

    void Update()
    {
        if(canMove)
            MoveShip(shipSpeed);

        if (health <= 0)
            SinkShip();

         if(transform.position.z < zLimit)
            Destroy(this.gameObject);
    }

    private void MoveShip(float speed){
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void SinkShip(){
        canMove = false;
        transform.Translate(0.5f * Time.deltaTime * Vector3.down);
        mesh.transform.Rotate(Vector3.up, -6 * 2 * Time.deltaTime);

        timePass += Time.deltaTime;
        if(timePass > destroyTimer){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Projectile"){
            health -= 15;
        }
    }
}
