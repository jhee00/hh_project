using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitterControll : MonoBehaviour {

    Animator aniCtrl;
    public int curBase = 0;

	// Use this for initialization
	void Start () {
        aniCtrl = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Swing(AnimationEvent animationEvent)
    {
        //Debug.Log("Swing");
        //Debug.Log("HitterControll Swing() = " + animationEvent.intParameter);

        if(curBase == 0) aniCtrl.SetTrigger("swingTrigger");

        // isHit == true -> BaseRun Ani 

        if(animationEvent.intParameter == 1) BaseRun();
    }

    public void BaseRun()
    {
        //int destBase = (curBase + 1) % 4 ;

        //iTween.MoveTo(gameObject, AnimationManager.instance.bases[destBase].transform.position, 5.0f); 

        StartCoroutine(BaseRunCouroutine());
    }

    IEnumerator BaseRunCouroutine()
    {
        //Debug.Log("BaseRun");
        float sec = 7.0f;

        yield return new WaitForSeconds(curBase == 0 ? 2.0f : 0.8f);
      
        aniCtrl.SetBool("isRun", true);

        int destBase = (curBase + 1) % 4 ;

        //iTween.MoveTo(gameObject, AnimationManager.instance.bases[destBase].transform.position, sec);
        iTween.MoveTo(gameObject, iTween.Hash("position", AnimationManager.instance.bases[destBase].transform.position,
                                              "easeType", iTween.EaseType.linear,
                                              "time", sec));

        yield return new WaitForSeconds(sec);

        aniCtrl.SetBool("isRun", false);
    }
}
