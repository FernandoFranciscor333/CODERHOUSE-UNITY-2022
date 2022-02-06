using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        EnableCamera(0, true);
    }

    // Update is called once per frame
    void Update()
    {
        SetCameras();
    }
    
    private void SetCameras(){
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            EnableCamera(0, true);
            EnableCamera(1, false);
            EnableCamera(2, false);
            EnableCamera(3, false);
            EnableCamera(4, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            EnableCamera(0, false);
            EnableCamera(1, true);
            EnableCamera(2, false);
            EnableCamera(3, false);
            EnableCamera(4, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)){
            EnableCamera(0, false);
            EnableCamera(1, false);
            EnableCamera(2, true);
            EnableCamera(3, false);
            EnableCamera(4, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)){
            EnableCamera(0, false);
            EnableCamera(1, false);
            EnableCamera(2, false);
            EnableCamera(3, true);
            EnableCamera(4, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)){
            EnableCamera(0, false);
            EnableCamera(1, false);
            EnableCamera(2, false);
            EnableCamera(3, false);
            EnableCamera(4, true);
        }
    }

    void EnableCamera(int position, bool status){
        cameras[position].SetActive(status);
    }
}
