using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DevilObj : MonoBehaviour,ICollectable
{
    public static Action devilcollect;

    public void DoTrig()
    {
       
        if (!PlayerController.Instance.playerStrategy.normal.firstSide)
        {
            PlayerController.Instance.playerStrategy.normal.AssigDevil();
            PlayerController.Instance.playerStrategy.normal.firstSide = true;
            GameObject newPar2 = Instantiate(ParticlePool.Instance.firstCollect, gameObject.transform.position, Quaternion.identity);
            Destroy(newPar2, 1f);
        }
        devilcollect?.Invoke();
        GameObject newPar = Instantiate(ParticlePool.Instance.devilCollect, gameObject.transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);
        Destroy(newPar, 1f);
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
