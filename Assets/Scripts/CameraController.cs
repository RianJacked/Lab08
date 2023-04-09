using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset1 = new Vector3(0.0f,3f,-2f);
    public Vector3 offset = new Vector3(0.0f, 1f, 0.0f);
    [SerializeField]
    private enum cameraFollowMode
    {
        FP,
        TP1,
        TP2,
    }
    [SerializeField] private cameraFollowMode followMode = cameraFollowMode.TP1;
    public Vector3 defaultPos = new Vector3(10f,2f,-12f);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentMode = (int)followMode;
            currentMode = ((currentMode == Enum.GetValues(typeof(cameraFollowMode)).Length - 1) ? 0 : currentMode+=1);
            followMode = (cameraFollowMode)currentMode;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (followMode)
        {
            case cameraFollowMode.FP://5.2.3
                transform.position = player.transform.position + offset;
                transform.rotation = player.transform.rotation;
                transform.rotation = new Quaternion(0, Mathf.Clamp(player.transform.rotation.y, -90f, 90f), 0, 1);
                break;
            case cameraFollowMode.TP1://5.2.1
                transform.position = defaultPos;
                smoothRotation();
                break;
            case cameraFollowMode.TP2://5.2.2
                //transform.rotation = new Quaternion(cameraDefaultTrans.rotation.x, Mathf.Clamp(player.transform.rotation.y, -45f, 45f), 0, 1);
                transform.position = player.transform.position - player.transform.forward*2f;
                transform.LookAt(player.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                break;
        }
    }

    void smoothRotation() // Point at player but not move
    {
        Vector3 direc = (player.transform.position - transform.position).normalized;
        Quaternion rotGoal = Quaternion.LookRotation(direc);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotGoal,.01f);
    }
}
