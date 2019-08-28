using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* defenders 
    0 포수
    1 1루수
    2 2루수
    3 3루수
    4 투수
    5 유격수
    6 좌익수
    7 중견수 
    8 우익수
    */

public class AnimationManager : MonoBehaviour {

    public static AnimationManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public List<GameObject> hitters;
    public GameObject catcher;

   
    public GameObject[] defenders;

    public GameObject[] bases;

    bool isHitted;
    GameObject nearestPlayer = null;

    public Transform[] sendPaths;
    int curSendPathsIdx;

    public GameObject runnerPrefap;
    public bool[] runners;

    public Transform hitterTr;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
            
        DontDestroyOnLoad(gameObject);
    }


	// Use this for initialization
	void Start () 
    {
        Init();
	}

    void Init()
    {
        curSendPathsIdx = 0;

        hitters.Clear();

        GenerateRunners();
    }

    public void GenerateRunners()
    {
        GameObject parent = GameObject.Find("Players");

        GameObject hitter = Instantiate(runnerPrefap, hitterTr.position, hitterTr.rotation, parent.transform);
        hitter.GetComponent<HitterControll>().curBase = 0;
        hitters.Add(hitter);

        for (int i = 0; i < runners.Length; i++)
        {
            if (runners[i] == false) continue;
            if (i >= 3) break;

            GameObject go = Instantiate(runnerPrefap, bases[(i + 1)].transform.position, Quaternion.identity, parent.transform);
            go.GetComponent<HitterControll>().curBase = (i + 1);

            hitters.Add(go);
        }
    }

    public void Pitched(AnimationEvent animationEvent)
    {
        //isCatcherPath = Random.Range(0f, 1f) < 0.5f;

        animationEvent.intParameter = isHitted ? 1 : 0;
        Debug.Log("AnimationManager Pitched() = " + animationEvent.intParameter);
        //players.SendMessage("Pitched", animationEvent);
        BaseballControll.instance.Pitched(animationEvent);
    }

    public void HitterSwing(AnimationEvent animationEvent)
    {
        isHitted = Random.Range(0f, 1f) < 0.5f;

        animationEvent.intParameter = isHitted ? 1 : 0;
        Debug.Log("AnimationManager HitterSwing() = " + animationEvent.intParameter);

        hitters[0].SendMessage("Swing", animationEvent);

        if(isHitted)
        {
            TryCatch();
        }
    }

    public void TryCatch()
    {
        int lastIndex = BaseballControll.instance.hitterPaths.Length - 1;
        Transform destTr = BaseballControll.instance.hitterPaths[lastIndex].transform;

        float dist = 1000.0f;

        foreach (GameObject go in defenders)
        {
            float tempDist = Vector3.Distance(go.transform.position, destTr.position);
            if (tempDist < dist)
            {
                nearestPlayer = go;
                dist = tempDist;
            }
        }

        if (nearestPlayer) nearestPlayer.SendMessage("TryCatchBall", destTr);
    }


    public void SendBall()
    {
        if(sendPaths.Length > curSendPathsIdx)
        {
            nearestPlayer.GetComponent<DefenderControll>().SendBall(sendPaths[curSendPathsIdx++]);
        }
        else
        {
            curSendPathsIdx = 0;
        }
    }
}
