using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherControll : MonoBehaviour {

    Animator aniCtrl;
	// Use this for initialization
	void Start () {

        aniCtrl = GetComponent<Animator>();

        //Pitching();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pitching()
    {
        aniCtrl.SetTrigger("pitchingTrigger");
    }

    void Pitched(AnimationEvent animationEvent)
    {
        AnimationManager.instance.Pitched(animationEvent);
        //BaseballControll.instance.Pitched(animationEvent);
    }

    void HitterSwing(AnimationEvent animationEvent)
    {
        AnimationManager.instance.HitterSwing(animationEvent);
    }

}
