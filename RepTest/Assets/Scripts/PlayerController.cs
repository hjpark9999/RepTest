using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject logicObject;
    private Logic logic;

    void Start()
    {
        logic = logicObject.GetComponent<Logic>();
    }

    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider == null) return;

            if(hit.collider.tag == "Plant")
            {
                bool isReleased = hit.collider.GetComponent<TreeObject>().IsReleasedTree();
                TreeObject tree = hit.collider.GetComponent<TreeObject>();

                switch (logic.GetAction())
                {
                    case Logic.NONE_STATE: return;
                    case Logic.WATER_STATE: 
//                        if(isReleased) return;
                        tree.GrowTree();
                        break;
                    case Logic.COLLECT_STATE: 
                        if(isReleased)
                        {
                            tree.CutTree();
                        }
                        break;
                    }

                Debug.Log("커진다 " +hit.collider.gameObject.name);
            }
        }

#elif UNITY_ANDROID
    if(Input.touchCount >= 1)
    {
        switch Input.GetTouch(0).phase)
        {
            case TouchPhase.Began: Debug.Log("터치시작"); break;
            case TouchPhase.Moved: Debug.Log("드래깅"); break;
            case TouchPhase.Canceled: Debug.Log("터치 입력 취소"); break;
            case TouchPhase.Stationary: Debug.Log("?"); break;
            case TouchPhase.Ended: Debug.Log("터치종료"); break;
        }
     }
#endif
    }

}
