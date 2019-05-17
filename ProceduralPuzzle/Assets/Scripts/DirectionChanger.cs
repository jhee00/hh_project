using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVE_DIR
{
    right = 0,
    left,
    forward,
    backward
}


public class DirectionChanger : MonoBehaviour
{

    GameObject targetObj; // 이동시킬 타겟 

    public Texture2D imgTexture; // 사용할 이미지 텍스쳐
    public MOVE_DIR moveDir; // 이동 방향 - DirectionChanger에서는 어느 방향으로 가게 할지를 컨트롤

    // Use this for initialization
    void Start()
    {
        
        if (imgTexture) 
        {
            // (Texture2D, Rect, pivot, pixelPerUnit)
            Sprite spr = Sprite.Create(imgTexture, new Rect(128 * (int)moveDir, 0, 128, 128), new Vector2(0.5f, 0.5f), 128);
            GetComponent<SpriteRenderer>().sprite = spr;
        }
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
        }
    }

    public void ChangeDir()
    {
        // 타겟 오브젝트가 없으면 행동 X
        if (!targetObj) return; 

        targetObj.GetComponent<moveObject>().ChangeDir(moveDir);
    }

    public void Work()
    {
        ChangeDir();
    }
}
