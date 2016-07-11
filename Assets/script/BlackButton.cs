using UnityEngine;
using System.Collections;

public class BlackButton : BaseBlock
{
 
    void Start()
    {
        base.Start();
        clickIn = new BlackClick_nomral(score,gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
