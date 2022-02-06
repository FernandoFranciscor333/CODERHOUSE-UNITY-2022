using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float camerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingAround(target);
    }

    private void MovingAround(GameObject objective){
        transform.RotateAround(objective.transform.position, Vector3.up, camerSpeed * Time.deltaTime);
    }
}
