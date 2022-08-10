using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    public static PlayerPool Instance;
    public GameObject DevilObj;
    public GameObject AngelObj;
    public GameObject SoulObj;
    public List<GameObject> AngelWings = new List<GameObject>();
    public List<GameObject> DevilWings = new List<GameObject>();
    void Start()
    {
        if (Instance==null)
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
