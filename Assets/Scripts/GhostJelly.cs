using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJelly : MonoBehaviour
{
    public static GhostJelly instance;
    public Transform[] obstaclePoses;

    private int index = 0;
    public int getIndex(){return index;}
    private void Start()
    {
        transform.position = new Vector3(0, transform.position.y, obstaclePoses[index].transform.position.z);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScaleOfTheGhost(Vector3 moveVector, Vector3 posVector)
    {
        transform.localScale = moveVector;
        transform.position = new Vector3(0, posVector.y, transform.position.z);
    }

    public void ChangePositionOfTheGhost()
    {
        index++;
        if (obstaclePoses.Length  > index)
        {
            transform.position = new Vector3(0, transform.position.y, obstaclePoses[index].transform.position.z);
        }
    }
}
