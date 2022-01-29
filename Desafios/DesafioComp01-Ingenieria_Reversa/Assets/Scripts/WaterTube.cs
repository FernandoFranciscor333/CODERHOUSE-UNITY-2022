using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTube : MonoBehaviour
{    
    [SerializeField] GameObject water;
    [SerializeField] float incrementalWaterRate = 0.2f;
    [SerializeField] float drainWaterRate = 0.1f;

    void Update()
    {
        DrainWater();
    }

    public void DrainWater(){
        if(water.gameObject.transform.localScale.y >= 0.01){
            water.gameObject.transform.localScale -= new Vector3(0,drainWaterRate,0)*Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Proyectile"){
            if(water.gameObject.transform.localScale.y <= 0.8){
                water.gameObject.transform.localScale += new Vector3(0,incrementalWaterRate,0);
            }
        }
    }
}
