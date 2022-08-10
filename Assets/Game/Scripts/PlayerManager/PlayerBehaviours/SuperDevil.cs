using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDevil : MonoBehaviour,IStrategy
{
    public int counter { get; set; }

    public void DoStatus()
    {
        //PlayerController.Instance.gameObject.AddComponent<SuperDevil>();
        foreach (var item in PlayerPool.Instance.DevilWings)
        {
            item.gameObject.SetActive(true);
        }
        Debug.Log("SuperDevil");
        PlayerPool.Instance.DevilObj.gameObject.GetComponent<Animator>().SetTrigger("Fly");
        DevilObj.devilcollect += CounterDevil;
        AngelObj.angelcollect += CounterAngel;

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



        if (counter >= 5)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.feverDevil);


        }
    }
    void CounterAngel()
    {
        counter--;
        PlayerController.Instance.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);


        if (counter<=-1)
        {
            PlayerController.Instance.SetStrategy(PlayerController.Instance.playerStrategy.middleDevil);
            PlayerPool.Instance.DevilObj.gameObject.GetComponent<Animator>().SetTrigger("FlyRes");
            foreach (var item in PlayerPool.Instance.DevilWings)
            {
                item.gameObject.SetActive(false);
            }

        }
        Debug.Log("DevilKüçüldü");

    }
}
