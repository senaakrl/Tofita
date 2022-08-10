using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleDevil : MonoBehaviour,IStrategy
{
    public int counter { get; set; }

    public void DoStatus()
    {
        //PlayerController.Instance.gameObject.AddComponent<MiddleDevil>();
        
        DevilObj.devilcollect += CounterDevil;
        AngelObj.angelcollect += CounterAngel;
        Debug.Log(PlayerController.Instance.myStrategy);

    }
    private void OnDestroy()
    {
        DevilObj.devilcollect -= CounterDevil;
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

    void CounterDevil()
    {
        counter++;
        PlayerController.Instance.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);



        if (counter>=4)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.superDevil);

        }
    }
    void CounterAngel()
    {
        counter--;
        PlayerController.Instance.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);


        Debug.Log("DevilK???ld?");
        
    }
    
}
