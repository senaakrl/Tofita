using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBehaviour : MonoBehaviour, IStrategy
{
    public int counter { get; set; }
    public bool firstSide = false;

    public enum SELECTSIDE
    {
        ANGEL, DEVIL
    }
    public SELECTSIDE mySide;
    public void DoStatus()
    {
        //PlayerController.Instance.gameObject.AddComponent<NormalBehaviour>();
        EventAssig();
        Debug.Log(mySide);
        
    }
    private void OnDestroy()
    {
        AngelObj.angelcollect -= CounterAngel;
        DevilObj.devilcollect -= CounterDevil;
    }
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void AssigAngel()
    {
        mySide = SELECTSIDE.ANGEL;
        PlayerPool.Instance.AngelObj.SetActive(true);
        PlayerPool.Instance.SoulObj.SetActive(false);
        Debug.Log(mySide);

    }
    public void AssigDevil()
    {

        mySide = SELECTSIDE.DEVIL;
        PlayerPool.Instance.SoulObj.SetActive(false);
        PlayerPool.Instance.DevilObj.SetActive(true);


    }
    void EventAssig()
    {
        
        AngelObj.angelcollect += CounterAngel;
        DevilObj.devilcollect += CounterDevil;
    }
    void CounterAngel()
    {
        if (mySide==SELECTSIDE.ANGEL)
        {
            counter++;
            if (counter>=4)
            {
                PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.middleAngel);
            }
        }
        else
        {
            counter--;
        }
    }
    void CounterDevil()
    {
        if (mySide==SELECTSIDE.DEVIL)
        {
            counter++;
            if (counter>=4)
            {
                PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.middleDevil);
            }
        }
        else
        {
            counter--;
        }
    }

   


}
