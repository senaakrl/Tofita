using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrig : MonoBehaviour , ICollectable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
            
    }
    
    

    public void DoTrig()
    {
        Debug.Log("lol");
        PlayerController.Instance.gameObject.transform.root.gameObject.GetComponent<Dreamteck.Splines.SplineFollower>().followSpeed = 0;
        Camera.main.gameObject.SetActive(false);
        ObjectPool.Instance.endCam.gameObject.SetActive(true);
        ObjectPool.Instance.boss.GetComponent<Animator>().SetBool("Attack",true);
        PlayerPool.Instance.AngelObj.GetComponent<Animator>().SetBool("End", true);
        PlayerController.Instance.gameObject.GetComponent<SwerveMovement>().enabled = false;
        PlayerController.Instance.endBool = true;
        //StartCoroutine(camMove());
        //LeanTween.move(Camera.main.gameObject, ObjectPool.Instance.endCam.gameObject.transform.position, .8f);
        //LeanTween.rotate(Camera.main.gameObject, new Vector3(ObjectPool.Instance.endCam.gameObject.transform.rotation.x, ObjectPool.Instance.endCam.gameObject.transform.rotation.y, ObjectPool.Instance.endCam.gameObject.transform.rotation.z), .8f);
    }

    //IEnumerator camMove()
    //{
    //    //while (true)
    //    //{
    //    //    Debug.Log("while");

    //    //    if (ObjectPool.Instance.endCam.gameObject.transform.position.z-Camera.main.transform.position.z>=.1f)
    //    //    {
    //    //        Debug.Log("if");
    //    //        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(ObjectPool.Instance.endCam.gameObject.transform.position.x, ObjectPool.Instance.endCam.gameObject.transform.position.y, ObjectPool.Instance.endCam.gameObject.transform.position.z), 1f);
    //    //        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, ObjectPool.Instance.endCam.gameObject.transform.rotation, 0.27f);
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("ELSE");
    //    //        break;
    //    //    }

    //    //}
    //    ////yield return new WaitForSeconds(1f);
    //    //yield break;

        
        


    //}
}
