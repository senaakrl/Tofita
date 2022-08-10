using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAngle : MonoBehaviour,IStrategy
{
    public int counter { get; set; }

    public void DoStatus()
    {
        //PlayerController.Instance.gameObject.AddComponent<SuperAngle>();
        foreach (var item in PlayerPool.Instance.AngelWings)
        {
            item.gameObject.SetActive(true);
        }
        DevilObj.devilcollect += CounterDevil;
        AngelObj.angelcollect += CounterAngel;
        PlayerPool.Instance.AngelObj.gameObject.GetComponent<Animator>().SetTrigger("Fly");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        DevilObj.devilcollect -= CounterDevil;
        AngelObj.angelcollect -= CounterAngel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CounterDevil()
    {
        counter--;
        PlayerController.Instance.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);


        if (counter<=-1)
        {
            PlayerPool.Instance.AngelObj.gameObject.GetComponent<Animator>().SetTrigger("FlyRes");

            foreach (var item in PlayerPool.Instance.AngelWings)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    void CounterAngel()
    {
        counter++;
        PlayerController.Instance.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);



        if (counter >= 5)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.feverAngel);


        }
    }
}
