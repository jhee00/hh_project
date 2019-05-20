using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveObject : MonoBehaviour {

    public MOVE_DIR moveDir;
    Vector3 moveVec;
    public Texture2D imgTexture; // 사용할 이미지 텍스쳐
	// Use this for initialization
	void Start () {

        ChangeDir(moveDir);
        //StartCoroutine(UpdateCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position + moveVec + Vector3.back, Vector3.forward * 10.0f, Color.red);
	}

    public void ChangeDir(MOVE_DIR newMoveDir)
    {
        Sprite spr = Sprite.Create(imgTexture, new Rect(128 * (int)moveDir, 0, 128, 128), new Vector2(0.5f, 0.5f), 128);
        //GetComponent<SpriteRenderer>().sprite = spr; // SpiriteRenderer 컴포넌트가 현 상황에서 존재하지 않기 떄문에 주석 처리

        switch (newMoveDir)
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
    }
    public void Work()
    {
        LayerMask mask = LayerMask.GetMask("MovableTile");

        RaycastHit hit;
        if (Physics.Raycast(transform.position + moveVec + Vector3.back, Vector3.forward, out hit, 10.0f, mask))
        {
            transform.Translate(Vector3.up);
        }
    }
}
