using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class JellyMove : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public GameObject particle;
    public GameObject jelly;
    public GameObject ghost;
    public GameObject shadow;
    public GameObject levelCompletedImage;
    public GameObject gameOverImage;
    public GameObject gameNameImage;
    public GameObject background;
    public Text levelCountText;
    public Button nextLevelButton;
    public Button restartButton;
    public Transform camRotator;

    public float minY, maxY;
    public float minX, maxX;
    public float speed;
    public float tRestitution;
    public float tFinish;
    public float rSpeed;
    public float jSpeed;

    Vector3 moveVector;
    Vector3 posVector;
    float zPositionFinishPose;
    float startTimer;
    float finishTimer;
    bool isFinished;
    bool isLost;
    bool isEnterBridge;
    bool isStart;
    bool isCrash;
    bool isStartTimer;
    bool startJump;
    bool finishJump;
    int gateCount = 0;
    int levelCount=0;


    public bool getIsFinished()
    {
        return isFinished;
    }

    public float getZPositionFinishPose()
    {
        return zPositionFinishPose;
    }

    void Start()
    {
        levelCount = PlayerPrefs.GetInt("lc");
        levelCountText.text = "LEVEL " + levelCount;
        //float dist = Vector3.Distance(other.position, transform.position);
        //Time.timeScale = 0.3f;
        gameNameImage.SetActive(true);
        Physics.IgnoreLayerCollision(6, 7);
    }

    private void FixedUpdate()
    {
        //Debug.Log("index:"+shadow.GetComponent<ShadowJelly>().getIndex());
        if (Input.GetMouseButtonDown(0))
        {
            isStartTimer = true;
        }
        if (isStartTimer)
        {
            startTimer += Time.deltaTime;
            gameNameImage.SetActive(false);
            if (!isStart) 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,0), rSpeed);
            if (!startJump)
            {
                rb.AddForce(0, jSpeed, 0);
                startJump = true;
            }
            if (startTimer >= 1.3f)
            {
                isStart = true;
            }
        }
        if (isStart)
        {
            if(gateCount< ghost.GetComponent<GhostJelly>().obstaclePoses.Length)
            {
                ghost.SetActive(true);
                shadow.SetActive(true);
            }
            
            if (!isFinished)
            {
                Move();
            }
           
            
            if (isFinished)
            {
                finishTimer += Time.deltaTime;
                transform.localScale = new Vector3(2.5f, 2.5f, 1f);
                transform.DOMove(new Vector3(0, 1.25f, zPositionFinishPose), tFinish).OnComplete(() => {
                    //jump
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -180, 0), rSpeed);
                });
                if (finishTimer >= 3f)
                {
                    camRotator.parent = transform;
                    levelCompletedImage.SetActive(true);
                    nextLevelButton.gameObject.SetActive(true);
                    background.SetActive(true);
                }
                
            }
            else if (isLost)
            {
                gameOverImage.SetActive(true);
                restartButton.gameObject.SetActive(true);
                background.SetActive(true);
            }
            else if (!isEnterBridge && !isCrash)
            {
                ChangeScale();
                ChangeGhostAndShadow();
            }
        }
    }

    void Update()
    {
        // cam.transform.position = new Vector3(6, 4, transform.position.z - 21);
    }

    public void ChangeScale()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20;

        moveVector = cam.ScreenToWorldPoint(mousePos);
        moveVector.z = transform.localScale.z;
        moveVector.y = Mathf.Clamp(moveVector.y, minY, maxY);
        moveVector.x = Mathf.Clamp(maxX / moveVector.y, minX, maxX);
        transform.localScale = moveVector;

        posVector = cam.ScreenToWorldPoint(mousePos);
        posVector.z = transform.position.z;
        posVector.y = Mathf.Clamp(moveVector.y / 2, minY / 2, maxY / 2);
        posVector.x = transform.position.x;
        transform.position = posVector;
        
        //GetComponent<BoxCollider>().size = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void ChangeGhostAndShadow()
    {
        GhostJelly.instance.ChangeScaleOfTheGhost(moveVector, posVector);
        ShadowJelly.instance.ChangeScaleOfTheShadow(moveVector, posVector, jelly);
    }

    public void Move()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.fixedDeltaTime);
    }

    public void PressButton(int buttonNo)
    {
        if (buttonNo == 0)//restart
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (buttonNo == 1)//next level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isCrash = true;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-1500,1500), Random.Range(1000, 1500), 0);
            collision.gameObject.layer = 7;
            transform.DOMoveZ(transform.position.z - 5, tRestitution).OnComplete(() => {
                isCrash = false;
            });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            zPositionFinishPose = other.transform.position.z+20;
            isFinished = true;
            levelCount++;
            PlayerPrefs.SetInt("lc", levelCount);
            particle.GetComponent<ParticleSystem>().Play();
        }
        if (other.gameObject.tag == "BridgeEntry")
        {
            isEnterBridge = true;
        }
        if (other.gameObject.tag == "BridgeExit")
        {
            isEnterBridge = false;
        }
        if (other.gameObject.tag == "BridgeFall")
        {
            isLost = true;
            ghost.GetComponent<GhostJelly>().gameObject.SetActive(false);
            shadow.GetComponent<ShadowJelly>().gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            gateCount++;
            if (gateCount < ghost.GetComponent<GhostJelly>().obstaclePoses.Length)
            {
                ghost.GetComponent<GhostJelly>().ChangePositionOfTheGhost();
                shadow.GetComponent<ShadowJelly>().ChangePositionOfTheShadow();
            }
            else
            {
                ghost.SetActive(false);
                shadow.SetActive(false);
            }
        }
    }
}
