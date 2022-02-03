using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    [SerializeField] private float balloonSpeed = 10f;
    [SerializeField] private Vector3 direction = new Vector3(0,1,0);
    [SerializeField] private float destroyTimer = 6f;
    private float timePass=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction, balloonSpeed);

        timePass += Time.deltaTime;
        if(timePass > destroyTimer){
            DestroyBalloon();
        }
    }

    public void Move(Vector3 dir, float speed){
        transform.Translate(speed * dir * Time.deltaTime);
    }

    public void DestroyBalloon(){
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Arrow"){
            Destroy(this.gameObject);
        }
    }
}
