using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject CR;
    public GameObject finLine;
    public Transform jelly;
    public Vector3 offset;
    public float lerpValue;

    private void LateUpdate()
    {
        
        if (jelly.GetComponent<JellyMove>().getIsFinished())
        {
            transform.LookAt(jelly);
            transform.parent = CR.transform;
            
        }
        else
        {
            Vector3 desPos = jelly.position + offset;
            transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
        }
    }
}
