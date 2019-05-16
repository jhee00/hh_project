using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// step 1 
// 각 오브젝트를 리스트에 담아서 순차적으로 호출
// 오브젝트가 추가 될때마다 update 코루틴을 수정해야하는 단점이 있음

// step 2
// step 1 의 단점을 수정하기 위해 map 혹은 dictionary에 담아서 enum만 추가하면 되도록 관리

public class WorkManager : MonoBehaviour {

    public bool pause;
    public List<moveObject> moveObjectList;
    public List<DirectionChanger> dirChangerList;

	// Use this for initialization
	void Start () {
        StartCoroutine(RunObjectsCoroutine()); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RunObjectsCoroutine()
    {
        int tick = 0;
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            if(!pause) tick++;

            if(tick >= 5)
            {
                tick = 0;

                for (int i = 0; i < moveObjectList.Count; i++)
                {
                    moveObjectList[i].Work();
                    //moveObjectList[i].SendMessage("Work");
                }

                for (int i = 0; i < dirChangerList.Count; i++)
                {
                    dirChangerList[i].Work();
                }

            }
        }

        yield return null;
    }
}
