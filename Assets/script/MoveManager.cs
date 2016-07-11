using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveManager : MonoBehaviour
{

    public List<GameObject> blockList=new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
    }

    // Update is called once per frame
    void Update()
    {
        blockList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Row"));
        Vector3 old;
        for (int i = 0; i < blockList.Count; i++)
        {
            old = blockList[i].transform.position;
            blockList[i].transform.position = new Vector3(old.x, old.y + 0.2f, old.z);

            if (blockList[i].GetComponent<Row>().state == Row.State_Pos.Out)
            {
                blockList[i].GetComponent<Row>().DestroyChildren();
                Destroy(blockList[i]);
                blockList.RemoveAt(i);
            }
        }




    }
}
