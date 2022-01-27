using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 10f;
    [SerializeField] private Vector3 direction = new Vector3(0,0,1);
    [SerializeField] private float damage = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction, ballSpeed);
    }

    public void Move(Vector3 dir, float speed){
        transform.Translate(speed * dir * Time.deltaTime);       
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "BackWall"){
            Destroy(this.gameObject);
        }
    }
}
