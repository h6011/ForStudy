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
    /// 땅에 서있는지 아닌지 여부 확인 (IsGround)
    /// </summary>
    private void checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, LayerMask.GetMask("Wall", "Ground"));
        if (hit) { isGround = true; } else { isGround = false; }
    }

    /// <summary>
    /// 플레이어를 움직이게 하는 함수
    /// </summary>
    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDir.y = rigid.velocity.y;

        rigid.velocity = moveDir;
    }

    /// <summary>
    /// 점프 작동 함수
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
    /// 중력 제어
    /// </summary>
    private void checkGravity()
    {
        /*
         * 여기에 버그 있음 점프 이상함
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
