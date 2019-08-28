using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
        Vector3[] vector3s = new Vector3[3];

        vector3s[0] = Vector3.zero;
        vector3s[1] = Vector3.one;
        vector3s[2] = new Vector3(1,0,1);

        iTween.MoveTo(gameObject, iTween.Hash("path", vector3s, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

