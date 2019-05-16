using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{

    GameObject targetObj;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MoveObject")
        {
            targetObj = other.gameObject;
            moveObject moveObj = other.GetComponent<moveObject>();

            if (moveObj)
            {
                string dirSpriteName = GetComponent<SpriteRenderer>().sprite.name;
                Debug.Log(dirSpriteName);
                ChangeDir(moveObj, dirSpriteName);
            }
        }
    }

    public void ChangeDir(moveObject moveObj, string newDirection)
    {
        MOVE_DIR moveDir = MOVE_DIR.right;

        switch (newDirection)
        {
            case "SetDirection_0":
                moveDir = MOVE_DIR.right;
        break;

            case "SetDirection_1":
                moveDir = MOVE_DIR.left;
        break;

            case "SetDirection_2":
                moveDir = MOVE_DIR.backward;
        break;

            case "SetDirection_3":
                moveDir = MOVE_DIR.forward;
        break;
    }
    moveObj.ChangeDir(moveDir);
    }

public void Work()
{
    if (targetObj)
    {

    }
}
}
