using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDummy : MonoBehaviour{

    public GameObject[] plant;

    private int index = 0;

    // Start is called before the first frame update
    void Start(){
        for(int i = 0; i< plant.Length; i++)
        {
            plant[i].GetComponent<Plant>().Init();
        }
    }

    // Update is called once per frame
    void Update(){
        if (plant[index].GetComponent<Plant>().IsMax){
            if (this.index==plant.Length-1) return;

            index++;
        }
        else{
            plant[index].GetComponent<Plant>().IncreasePlant();

        }
    }
}
