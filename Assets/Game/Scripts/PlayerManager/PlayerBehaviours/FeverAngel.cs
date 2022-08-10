using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverAngel : MonoBehaviour,IStrategy
{
    public int counter { get; set ; }

    public void DoStatus()
    {
        DevilObj.devilcollect += CounterDevil;
    }
    private void OnDestroy()
    {
        DevilObj.devilcollect -= CounterDevil;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CounterDevil()
    {
        counter--;
        if (counter<=-1)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.superAngle);

        }
    }
}
