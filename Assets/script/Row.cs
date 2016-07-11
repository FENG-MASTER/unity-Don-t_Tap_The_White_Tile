using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour
{

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    public enum State_Pos { Start, Moving, Out };
    public State_Pos state = State_Pos.Start;
    private bool hasInit = false;

    public void Init(GameObject o1,GameObject o2,GameObject o3,GameObject o4)
    {
        b1 = o1;
        b2 = o2;
        b3 = o3;
        b4 = o4;
        hasInit = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!hasInit){
            return;
        }
        UpdatePosition(b1, 1);
        UpdatePosition(b2, 2);
        UpdatePosition(b3, 3);
        UpdatePosition(b4, 4);
        if (transform.position.y > -38 && transform.position.y < -18)
        {
            state = State_Pos.Moving;
        }
        else if (transform.position.y < -38)
        {
            state = State_Pos.Start;
        }
        else if (transform.position.y > -18)
        {
            state = State_Pos.Out;
        }

    }

    private void UpdatePosition(GameObject obj, int num)
    {
        Vector3 v = this.transform.position;
        obj.transform.position = new Vector3(v.x - (num * 3 - 7.5f), v.y, v.z);
    }

    public void DestroyChildren()
    {
        Destroy(b1);
        Destroy(b2);
        Destroy(b3);
        Destroy(b4);
    }


}
