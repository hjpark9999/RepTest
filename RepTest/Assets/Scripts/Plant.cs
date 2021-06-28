using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Seed {

    public string name;
    public int purchasePrice;
    public int sellPrice;
    public int maxSize;
    float plantOpacity = 0f;
    float plantScale = 0f;

    private bool isMaxed = false;

    public bool IsMax {
        get
        {
            return this.isMaxed;
        }
    }

    public void Init()
    {
        this.plantOpacity=0f;
        this.plantScale=0f;
    }



    void Start(){
        this.Init(name, 0, maxSize, purchasePrice, sellPrice);

        this.plantOpacity = this.GetComponent<SpriteRenderer>().color.a;
        this.plantScale=this.transform.localScale.x;
    }


    public void IncreasePlant(){
        if(this.plantOpacity <=60)
        {
            this.plantOpacity+=5f;
        }
        else
        {

            if(this.plantScale >=0.99f)
            {
                this.isMaxed=true;
                this.plantOpacity=1f;
                this.plantScale=1f;
                return;
            }
            else
            {
                this.plantOpacity+=0.01f;
                this.plantScale+=0.01f;
            }
            
        }

    }

    // Update is called once per frame
    void Update(){
        if (this.IsMax) return;

        this.GetComponent<SpriteRenderer>().color=new Color(1, 1, 1, this.plantOpacity);
        this.transform.localScale=new Vector3(this.plantScale, 1, 1);
    }
}
