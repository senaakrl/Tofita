using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool Instance;
    public GameObject devilCollect;
    public GameObject angelCollect;
    public GameObject firstCollect;
    public GameObject angelEndAttack;
    public GameObject devilEndAttack;
    public GameObject devilBossEnd;
    public GameObject angelBossEnd;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
