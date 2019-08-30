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
}
