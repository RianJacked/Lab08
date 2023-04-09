using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float verInput, horiInput;
    [SerializeField] private Animator ani;
    [SerializeField] private float speed;
    public GameController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        verInput = Input.GetAxis("Vertical");
        horiInput = Input.GetAxis("Horizontal");
        speed = (Input.GetKey(KeyCode.R)) ? 6f : 3f;
        ani.SetFloat(controller.speedPara, verInput*speed);
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if(horiInput > 0)
            {
                ani.Play(controller.TurnOnSpotRightState);
            }else if (horiInput < 0)
            {
                ani.Play(controller.TurnOnSpotLeftState);
            }
        }


    }
}
