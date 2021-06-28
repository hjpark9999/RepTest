using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {
    private string name;
    private int count;
    private int maxSize;
    private int size;
    private int purchasePrice;
    private int sellPrice;

    // 초기화
    protected void Init(string name, int count, int maxSize, int purchase, int sell) {
        this.name=name;
        this.count=count;
        this.maxSize=maxSize;
        this.size=0;
        this.purchasePrice=purchase;
        this.sellPrice=sell;
    }

    public string SeedName
    {
        get{
            return this.name;
        }
    }

    public int SeedCount
    {
        get
        {
            return this.count;
        }
    }

    public int SeedSize
    {
        get
        {
            return this.size;
        }
    }

    public int SeedMaxSize
    {
        get
        {
            return this.maxSize;
        }
    }

    public int SeedPurchasePrice
    {
        get
        {
            return this.purchasePrice;
        }
    }


    public int SeedSellPrice
    {
        get
        {
            return this.sellPrice;
        }
    }

}