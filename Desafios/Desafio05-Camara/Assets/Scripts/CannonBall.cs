using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    //[SerializeField] private float shootSpeed = 10f;
    //[SerializeField] private Vector3 direction = new Vector3(1,0,0);
    [SerializeField] private float destroyTimer = 3f;
    private float timePass=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move(direction, shootSpeed);

        timePass += Time.deltaTime;
        if(timePass > destroyTimer){
            DestroyProyectile();
        }
    }

    /*public void Move(Vector3 dir, float speed){
        transform.Translate(speed * dir * Time.deltaTime);
    }*/

    private void DestroyProyectile(){
        Destroy(this.gameObject);
    }
}
