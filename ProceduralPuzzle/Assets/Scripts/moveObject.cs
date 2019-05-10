using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVE_DIR{
    right = 0,
    left,
    forward,
    backward
}

public class moveObject : MonoBehaviour {

    public MOVE_DIR moveDir;
    Vector3 moveVec;
    string dirSprite;

	// Use this for initialization
	void Start () {
        StartCoroutine(updateCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
        
        switch (moveDir)
        {
            case MOVE_DIR.right:
                transform.eulerAngles = new Vector3(0, 0, 270);
                moveVec = Vector3.right;
                break;

            case MOVE_DIR.left:
                transform.eulerAngles = new Vector3(0, 0, 90);
                moveVec = Vector3.left;
                break;

            case MOVE_DIR.forward:
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveVec = Vector3.up;
                break;

            case MOVE_DIR.backward:
                transform.eulerAngles = new Vector3(0, 0, 180);
                moveVec = Vector3.down;
            break;
        }

        Debug.DrawRay(transform.position + moveVec + Vector3.back, Vector3.forward * 10.0f, Color.red);



	}

    public void work()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + moveVec + Vector3.back,Vector3.forward * 10.0f, out hit))
        {
            Debug.Log(hit.transform.name);
            transform.position = hit.transform.position;
        }
    }

    IEnumerator updateCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);

            work();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        

		if(other.tag == "Change")
        {
            dirSprite = other.GetComponent<SpriteRenderer>().sprite.name;

            Debug.Log(dirSprite);

            changeDir();
        }
	}


	void changeDir()
    {
        switch(dirSprite)
        {
            case "SetDirection_0":
                moveDir = MOVE_DIR.right;
                break;

            case "SetDirection_1":
                moveDir = MOVE_DIR.left;
                break;

            case "SetDirection_2":
                moveDir = MOVE_DIR.forward;
                break;

            case "SetDirection_3":
                moveDir = MOVE_DIR.backward;
                break;
        }
    }



}
