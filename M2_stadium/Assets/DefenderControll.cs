using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControll : MonoBehaviour {

    Animator aniCtrl;

	// Use this for initialization
	void Start () {
        aniCtrl = GetComponent<Animator>();
	}

    void TryCatchBall(Transform tr)
    {
        Debug.Log("TryCatchDist = " + Vector3.Distance(transform.position, tr.position));

        iTween.MoveTo(gameObject, iTween.Hash("delay", 0.8f,
                                              "position", tr,
                                              "easeType", iTween.EaseType.linear,
                                              "time", Vector3.Distance(transform.position, tr.position)
                                              ));
    }

    public void SendBall(Transform destTr)
    {
        aniCtrl.SetTrigger("sendBallTrigger");

        StartCoroutine(SendBallCouroutine(destTr));

        // 애니메이션 이벤트로 연출 붙이기
        //BaseballControll.instance.MoveToTargetPos(destTr.position);
    }

    IEnumerator SendBallCouroutine(Transform destTr)
    {
        yield return new WaitForSeconds(0.5f);
        BaseballControll.instance.MoveToTargetPos(destTr.position);
    }

}
