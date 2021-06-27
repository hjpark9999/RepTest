using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionButton : MonoBehaviour
{
    public GameObject logicObject;
    private Logic logic;

    public Sprite noneIcon;
    public Sprite waterIcon;
    public Sprite collectIcon;

    private void Awake()
    {
        logic = logicObject.GetComponent<Logic>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (logic.GetAction())
        {
            case Logic.NONE_STATE:
                this.GetComponent<Image>().sprite = noneIcon;
                break;
            case Logic.WATER_STATE:
                this.GetComponent<Image>().sprite = waterIcon;
                break;
            case Logic.COLLECT_STATE:
                this.GetComponent<Image>().sprite = collectIcon;
                break;
        }

    }

    public void ChangeState()
    {
        switch (logic.GetAction())
        {
            case Logic.NONE_STATE: logic.SetWaterState(); break;
            case Logic.WATER_STATE: logic.SetCollectState(); break;
            case Logic.COLLECT_STATE: logic.SetNoneState(); break;
        }
    }
}