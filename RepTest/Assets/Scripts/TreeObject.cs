using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    private float treeHeight;
    public TreeObject treePrefab;       // 생성할 트리의 프리팹

    private TreeObject nextTree = null; // 다음트리 지정
    private int treeLevel = 0;

    public float growthRate = 1f; // 아직 적용 안함---
    public float wateringRate = 1f; // 클릭하면 증가

    public const float INIT_HEIGHT = 10f; // 최소 수초 크기
    public const float MAX_HEIGHT = 30f; // 최대 수초 크기


    void Start()
    {
        treeHeight = INIT_HEIGHT;
        gameObject.name = "Tree-" + (treeLevel + 1); // 이름 지정

        InitTree();
    }

    // 최대크기 체크
    public bool IsReleasedTree()
    {
        return transform.localScale.x >= MAX_HEIGHT;
    }

    // 성장하는 중
    public void GrowTree()
    {

        if (nextTree != null) //
        {
//            Debug.Log("다음단계 트리로 갑니다");
            nextTree.GrowTree();
            return;
        }

        if (treeHeight + wateringRate > MAX_HEIGHT) // 수초 크기가 최대치인지 체크
        {
            float leftOver = treeHeight + wateringRate - MAX_HEIGHT; // 새로 올라오는 새싹 수초의 크기로 적용하려고 하는건데...
            treeHeight = MAX_HEIGHT;

            Debug.Log("트리 단계가 성장합니다. leftOver=" + leftOver);

            nextTree = Instantiate(treePrefab, gameObject.transform.parent); // 새싹 수초의 오브젝트 생성과 위치 지정
            nextTree.transform.position += new Vector3(0, MAX_HEIGHT, -0.1f); // TreeParent 위치에서 시작하고 싶은데 생성되는 윗번호가 지정 되는 것 같다
            nextTree.treeHeight = leftOver; //
            nextTree.treeLevel = treeLevel + 1;
 //           nextTree.DrawTree();
        }
        else
        {
            Debug.Log("트리 성장 " + treeHeight);
            treeHeight += wateringRate; // 수초 성장-클릭(wateringRate)
        }

        DrawTree();
    }

    // 초기화
    public void InitTree()
    {
        DrawTree();
     }


    // 수초 자르기 - 어디 자를건지 판단은 나중에, 저장도 해야되고
    public void CutTree()
    {
        Debug.Log("CutTree - " + gameObject.name);
        if (nextTree != null)
        {
            nextTree.CutTree();
            nextTree = null;
        }
        if (treeLevel != 0)
            Destroy(gameObject);
        else
            InitTree();
    }

    // 수초 크기만 정해준다
    private void DrawTree()
    {
        transform.localScale = new Vector3(treeHeight, treeHeight, 1);
    }
}
