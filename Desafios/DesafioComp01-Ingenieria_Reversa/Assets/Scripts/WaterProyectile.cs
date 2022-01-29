using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProyectile : MonoBehaviour
{
    [SerializeField] private float waterShootSpeed = 10f;
    [SerializeField] private Vector3 direction = new Vector3(0,0,1);

    void Update()
    {
        Move(direction, waterShootSpeed);
    }

    public void Move(Vector3 dir, float speed){
        transform.Translate(speed * dir * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "BackWall" || other.tag == "WaterTaker"){
            Destroy(this.gameObject);
        }
    }
}
