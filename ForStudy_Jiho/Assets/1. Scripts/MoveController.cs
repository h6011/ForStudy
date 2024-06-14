using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : PlayerStat
{


    

    private void OnDrawGizmos() 
    { 
        if (showGroundCheck)
        {
            Debug.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckLength), colorGroundCheck);
        } 
    }

    

    private void Update()
    {
        checkGround();
        moving();
        jump();
        checkGravity();
        doAnim();
    }


    /// <summary>
    /// ���� ���ִ��� �ƴ��� ���� Ȯ�� (IsGround)
    /// </summary>
    private void checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, LayerMask.GetMask("Wall", "Ground"));
        if (hit) { isGround = true; } else { isGround = false; }
    }

    /// <summary>
    /// �÷��̾ �����̰� �ϴ� �Լ�
    /// </summary>
    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDir.y = rigid.velocity.y;

        rigid.velocity = moveDir;
    }

    /// <summary>
    /// ���� �۵� �Լ�
    /// </summary>
    private void jump()
    {
        if (isGround == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    /// <summary>
    /// �߷� ����
    /// </summary>
    private void checkGravity()
    {
        /*
         * ���⿡ ���� ���� ���� �̻���
         */
        if (isGround == false)
        {
            verticalVelocity += Physics2D.gravity.y * Time.deltaTime;

            if (verticalVelocity < -10)
            {
                verticalVelocity = -10;
            }

        }
        else if (isJump == true)
        {
            isJump = false;
            verticalVelocity = jumpForce;
        }
        else if (isGround == true)
        {
            verticalVelocity = 0;
        }

        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);

    }

    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        anim.SetBool("IsGround", isGround);
    }


}
