using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverDevil : MonoBehaviour,IStrategy
{
    public int counter { get; set ; }

    public void DoStatus()
    {
        AngelObj.angelcollect += CounterAngel;
    }
    private void OnDestroy()
    {
        AngelObj.angelcollect -= CounterAngel;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CounterAngel()
    {
        counter--;
        if (counter<=-1)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.superDevil);

        }
    }
}
