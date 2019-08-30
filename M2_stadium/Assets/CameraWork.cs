using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{

    GameObject baseball;
    // Use this for initialization
    void Start()
    {
        baseball = BaseballControll.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(baseball.transform.position - Vector3.up * baseball.transform.position.y);
    }
}
