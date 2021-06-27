using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public const int COLLECT_STATE = 2;
    public const int WATER_STATE = 1;
    public const int NONE_STATE = 0;


    private enum USER_ACTION { NONE = 0, WATER, COLLECT };
    private USER_ACTION ACTION = USER_ACTION.NONE;


    public void SetWaterState()
    {
        Debug.Log("커져라");

        ACTION = USER_ACTION.WATER;
    }

    public void SetCollectState()
    {
        ACTION = USER_ACTION.COLLECT;

    }

    public void SetNoneState()
    {
        ACTION = USER_ACTION.NONE;
    }

    public int GetAction()
    {
        return (int)ACTION;
    }
}
