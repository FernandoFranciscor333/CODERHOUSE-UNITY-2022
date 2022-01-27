using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Cannon Movement")]
    [SerializeField][Range(-4,4)] private float xMovement = 0;
    [SerializeField] private float slideSpeed = 2;

    [Header("Shoot parameters")]
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject proyectile;
    [SerializeField] float shootRate = 5f;
    [SerializeField] float shootDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shootDelay, shootRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move(xMovement,slideSpeed);
    }

    public void Move(float x, float speed){
        transform.Translate(speed * new Vector3(x,0,0) * Time.deltaTime);
    }

    public void Shoot(){
        Instantiate(proyectile, spawner.transform);
    }
}
