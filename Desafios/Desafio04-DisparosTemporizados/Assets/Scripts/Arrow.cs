using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float arrowShootSpeed = 10f;
    [SerializeField] private Vector3 direction = new Vector3(1,0,0);
    [SerializeField] private float destroyTimer = 3f;
    [SerializeField] private float resizeMultiplier = 2f;
    [SerializeField] private KeyCode resizeKey = KeyCode.Space;
    private float timePass=0;
    private bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            Move(direction, arrowShootSpeed);

        ReSize();
        
        timePass += Time.deltaTime;
        if(timePass > destroyTimer){
            DestroyArrow();
        }
    }

    public void Move(Vector3 dir, float speed){
        transform.Translate(speed * dir * Time.deltaTime);
    }

    private void DestroyArrow(){
        Destroy(this.gameObject);
    }

    private void ReSize(){
        if(Input.GetKeyDown(resizeKey))
            transform.localScale *= resizeMultiplier;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall"){
            canMove = false;
        }
    }
}
