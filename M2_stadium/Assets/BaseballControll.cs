using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballControll : MonoBehaviour {

    public static BaseballControll instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    MeshRenderer renderer;

    public Transform[] catcherPaths;
    public Transform[] hitterPaths;

    public float midPosHeight = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        renderer = GetComponent<MeshRenderer>();
    }

	void Start () 
    {
        //MoveByPaths();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.E))
        {
            Vector3 pos = GetClickedObject(hitterPaths[hitterPaths.Length - 1].position);
            hitterPaths[hitterPaths.Length - 1].position = pos;
        }
	}

    private Vector3 GetClickedObject(Vector3 defaultPos) 
    {
        //충돌이 감지된 영역
        RaycastHit hit;

        //마우스 포이트 근처 좌표를 만든다.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //마우스 근처에 오브젝트가 있는지 확인
        if((Physics.Raycast(ray, out hit, 100.0f))) 
        {
            if(hit.collider.tag == "Field")
            {
                return hit.point;
            }
        }
        return defaultPos;
    } 

    public void MoveByPaths()
    {
        //iTween.MoveTo(gameObject, iTween.Hash("path", paths, "easeType", "easeOutExpo", "delay", .1, "time", 2));
    }

    public void MoveToTargetPos(Vector3 destPos)
    {
        
        iTween.MoveTo(gameObject, iTween.Hash("position", destPos,
                                              "easeType", iTween.EaseType.easeOutQuad,
                                              "time", 0.5f,
                                              "oncomplete", "BallDropped"));
    }

    public void Pitched(bool isHitted)
    {
        //Debug.Log("pitched");


        gameObject.transform.position = catcherPaths[0].position;
        renderer.enabled = true;

        Debug.Log(isHitted ? "hitterPaths" : "catcherPaths");

       
        //oncomplete  string  for the name of a function to launch at the end of the animation
        //oncompletetarget    GameObject  for a reference to the GameObject that holds the "oncomplete" method
        //oncompleteparams    Object  for arguments to be sent to the "oncomplete" method

        if(isHitted)
        {
            // 중간경로 계산 
            hitterPaths[hitterPaths.Length - 2].position = (hitterPaths[hitterPaths.Length - 1].position + hitterPaths[hitterPaths.Length - 3].position) * 0.5f + Vector3.up * midPosHeight;

            iTween.MoveTo(gameObject, iTween.Hash("path", hitterPaths,
                                              "easeType", iTween.EaseType.easeOutQuad,
                                              "time", 5.5f,
                                              "oncomplete", "BallDropped"));
        }
        else
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", catcherPaths,
                                             "easeType", iTween.EaseType.easeOutSine,
                                             "time", 0.5f));
        }

        //iTween.MoveTo(gameObject, destTr.position, 2);
        //iTween.MoveTo(gameObject, iTween.Hash("position", destTr, ));
    }

    public void BallDropped()
    {
        //if(tempDestBase > 0)
        //{
        //    AnimationManager.instance.SendBall(tempDestBase--);
        //}

        AnimationManager.instance.SendBall();
    }
}
