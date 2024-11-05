using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerrRigid;
    public float walkSpeed, walkBackSpeed, oldWalkSpeed, runSpeed, rotateSpeed;
    public bool isWalking;
    public Transform playerTrans;

    void Start()
    {
        
    }

    // ����ó�� ������ ���� �ֱ������� ȣ�� 
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerrRigid.velocity = transform.forward * walkSpeed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerrRigid.velocity = -transform.forward * walkBackSpeed * Time.deltaTime;
        }
    }

    // �� �����Ӹ��� ȣ��Ǹ� ���� ���� �� �ִϸ��̼� ���� 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            isWalking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotateSpeed*Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if(isWalking)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSpeed += runSpeed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSpeed = oldWalkSpeed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
    }
}
