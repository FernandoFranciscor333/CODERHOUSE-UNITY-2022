using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpawner : MonoBehaviour
{
    [Header("Moving parameters")]
    [SerializeField] float spawnerSpeed = 19f;
    [SerializeField] float xOffset = 18;
    private bool isMovingLeft;

    [Header("Spawn parameters")]
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] float spawnDelay = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isMovingLeft){
            Move(Vector3.left);
        } else {
            Move(Vector3.right);
        }

        if(transform.position.x >= xOffset){
            isMovingLeft = true;
        }

        if(transform.position.x <= -xOffset){
            isMovingLeft = false;
        }        
    }

    public void Move(Vector3 dir){
        transform.Translate(spawnerSpeed * dir * Time.deltaTime);
    }

        public void Spawn(){
            Instantiate(prefab, spawner.transform.position, prefab.transform.rotation);
    }
}
