using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int idleState, walkRunState, speedPara, TurnOnSpotLeftState, TurnOnSpotRightState, shiftPara;
    // Start is called before the first frame update
    void Awake()
    {
        idleState = Animator.StringToHash("Idle");
        walkRunState = Animator.StringToHash("Walk_Run"); 
        speedPara = Animator.StringToHash("speed");
        TurnOnSpotLeftState = Animator.StringToHash("TurnOnSpotLeftA");
        TurnOnSpotRightState = Animator.StringToHash("TurnOnSpotRightA");
        shiftPara = Animator.StringToHash("pressedShift");
    }
}
