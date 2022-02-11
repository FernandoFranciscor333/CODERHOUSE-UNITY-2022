using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 5f;
    private Vector2 currentInput;
    private Vector3 moveDirection;
    float speed = 3f;
    float xAxis;
    public bool beenResized = false;

    float halfSize = 0.5f;
    float doubleSize = 1f;
    

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
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

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Portal" && !beenResized){
            Resize(halfSize);
        }

        if(other.tag == "Portal" && beenResized){
            Resize(doubleSize);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Portal" && !beenResized){
            beenResized = false;
        } else {
            beenResized = true;
        }

    }

    
}
