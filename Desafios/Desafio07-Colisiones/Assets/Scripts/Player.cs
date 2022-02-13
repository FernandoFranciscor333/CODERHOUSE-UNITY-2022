using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float speed = 3f;

    //Movement
    private Vector2 currentInput;
    private Vector3 moveDirection;    
    float xAxis;

    //Booleans
    private bool beenResized = false;    
    private bool playerHasCrossed = false;

    //Resize
    float halfSize = 0.5f;
    float doubleSize = 1f;

    //Timer
    public float timePass = 0;
    public float coolDown = 2f;
    public float resizeCount = 0.5f;    

    private CharacterController characterController;
    public GameObject ob;    


    void Update()
    {
        Move();
        Rotate();

        if(playerHasCrossed){
            timePass += Time.deltaTime;
                    
            if(timePass > resizeCount){
                if(!beenResized){
                    Resize(halfSize);
                    beenResized = true;
                    playerHasCrossed = false;
                    timePass = 0;
                } else {
                    Resize(doubleSize);
                    beenResized = false;
                    playerHasCrossed = false;
                    timePass = 0;
                }
            }
        }
    }

    void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(){
        currentInput = new Vector2(speed * Input.GetAxis("Vertical"),speed * Input.GetAxis("Horizontal"));
        moveDirection = (transform.TransformDirection(Vector3.forward)*currentInput.x)
         + (transform.TransformDirection(Vector3.right) * currentInput.y);

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(){        
        xAxis += Input.GetAxis("Mouse X") * rotationSpeed;
        Quaternion angle = Quaternion.Euler(0,xAxis,0);
        transform.localRotation = angle;
    }

    public void Resize(float resize){
        transform.localScale = new Vector3(resize,resize,resize);
    }    

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Portal"){
            Debug.Log(other.name);
            playerHasCrossed = true;

            if(GameObject.Find(other.name).GetComponent("Shrinker") == null){
                Debug.Log("No se encontró ningun componente llamado Shrinker");
            } else {
                Debug.Log("Se encontró el componente Shrinker");
            }
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.name == "Wall"){
            
            Debug.Log(other.gameObject.name);
            
            timePass += Time.deltaTime;
        
            if(timePass > coolDown){
                float xRandomPosition = Random.Range(-3f,8f);
                float zRandomPosition = Random.Range(-5f,10f);
                float yRandomRotation = Random.Range(30f,-30f);

                other.gameObject.transform.position = new Vector3(xRandomPosition,2f,zRandomPosition);
                other.gameObject.transform.localRotation = Quaternion.Euler(0,yRandomRotation,0);   
                
                timePass = 0;
            }        
        }
    }    
}
