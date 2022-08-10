using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowJelly : MonoBehaviour
{
    public static ShadowJelly instance;
    public Transform[] obstaclePoses;

    private int index = 0;
    private float length;

    public int getIndex(){return index;}

    private void Start()
    {
        transform.position = new Vector3(0, transform.position.y, obstaclePoses[index].transform.position.z - length / 2);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScaleOfTheShadow(Vector3 moveVector, Vector3 posVector, GameObject gameObject)
    {
        length = Vector3.Distance(obstaclePoses[index].transform.position, gameObject.transform.position);
        transform.localScale = new Vector3(moveVector.x, moveVector.y, length);
        transform.position = new Vector3(0, posVector.y, obstaclePoses[index].transform.position.z-length/2);
    }

    public void ChangePositionOfTheShadow()
    {
        index++;
        if (obstaclePoses.Length > index)
        {
            transform.position = new Vector3(0, transform.position.y, obstaclePoses[index].transform.position.z);
        }
    }
}
