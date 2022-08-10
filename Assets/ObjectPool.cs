using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject endCam;
    public GameObject boss;
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

        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
