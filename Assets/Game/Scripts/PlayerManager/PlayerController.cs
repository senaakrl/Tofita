using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController Instance;
    public FacedePlayerStrategy playerStrategy = new FacedePlayerStrategy();
    public IStrategy myStrategy;
    public bool endBool = false;
    
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
        SetStrategy(playerStrategy.normal);
    }

    // Update is called once per frame
    void Update()
    {
        if (endBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ParticlePool.Instance.angelEndAttack.GetComponent<ParticleSystem>().Play();
                ParticlePool.Instance.devilBossEnd.transform.localScale -= new Vector3(.1f, .1f, .1f);

            }
        }
    }
    public void SetStrategy(IStrategy strategy)
    {

        Component c = gameObject.GetComponent<IStrategy>() as Component;
        if (c != null)
        {
            Destroy(c);
        }
        myStrategy = strategy;

        myStrategy.DoStatus();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>()!=null)
        {
            other.gameObject.GetComponent<ICollectable>().DoTrig();
        }
        
    }
    

}
public class FacedePlayerStrategy
{
    public NormalBehaviour normal;
    public MiddleAngel middleAngel;
    public SuperAngle superAngle;
    public MiddleDevil middleDevil;
    public SuperDevil superDevil;
    public FeverDevil feverDevil;
    public FeverAngel feverAngel;
    public FacedePlayerStrategy()
    {
        normal = new NormalBehaviour();
        middleAngel = new MiddleAngel();
        superAngle = new SuperAngle();
        middleDevil = new MiddleDevil();
        superDevil = new SuperDevil();
        feverDevil = new FeverDevil();
        feverAngel = new FeverAngel();
    }
}

