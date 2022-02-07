using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 3f;
    private float timePass=0;

    void Update()
    {
        timePass += Time.deltaTime;
        if(timePass > destroyTimer){
            DestroyProyectile();
        }
    }
    private void DestroyProyectile(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Water")
            Destroy(this.gameObject);
    }
}
