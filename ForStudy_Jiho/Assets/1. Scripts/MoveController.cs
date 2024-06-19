using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveController : PlayerStat
{
    //private void OnDrawGizmos() 
    //{ 
    //    if (showGroundCheck)
    //    {
    //        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckLength), colorGroundCheck);
    //    } 
    //}

    public void TriggerEnter(HitBox.ehitboxType _type, Collider2D _collision)
    {
        if (_type == HitBox.ehitboxType.WallCheck)
        {
            if (_collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                touchWall = true;
            }
        }
    }

    public void TriggerExit(HitBox.ehitboxType _type, Collider2D _collision)
    {
        if (_type == HitBox.ehitboxType.WallCheck)
        {
            if (_collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                touchWall = false;
            }
        }
    }


    private void Update()
    {
        checkTimer();
        checkGround();

        moving();
        jump();
        dash();

        checkGravity();
        doAnim();

        rotatePlayerByMouse();
    }

    

    private bool isPlayerWatchingLeft()
    {
        if (transform.localScale.x > 0) { return true; }
        else { return false; }
    }


    private void dash()
    {
        bool isPressedDashKeyBool = isPressedDashKey();

        if (dashTimer == 0.0f && isPressedDashKeyBool)
        {
            dashTimer = dashTime;
            verticalVelocity = 0;

            if (isPlayerWatchingLeft())
            {
                rigid.velocity = new Vector2(-dashSpeed, verticalVelocity);
            }
            else
            {
                rigid.velocity = new Vector2(dashSpeed, verticalVelocity);
            }

        }
    }

    private void checkTimer()
    {
        if (wallJumpTimer > 0.0f)
        {
            wallJumpTimer -= Time.deltaTime;
            if (wallJumpTimer < 0) { wallJumpTimer = 0; }
        }

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer < 0) { dashTimer = 0; }
        }

    }


    /// <summary>
    /// ���� ���ִ��� �ƴ��� ���� Ȯ�� (IsGround)
    /// </summary>
    private void checkGround()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, LayerMask.GetMask("Wall", "Ground"));
        //if (hit) { isGround = true; } else { isGround = false; }

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, groundCheckLength, groundCheckLayerint);
        if (hit) { isGround = true; } else { isGround = false; }

    }

    /// <summary>
    /// �÷��̾ �����̰� �ϴ� �Լ�
    /// </summary>
    private void moving()
    {
        if (wallJumpTimer > 0.0f || dashTimer > 0.0f)
        {
            return;
        }

        moveDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDir.y = rigid.velocity.y;

        rigid.velocity = moveDir;
    }

    /// <summary>
    /// ���� �۵� �Լ�
    /// </summary>
    private void jump()
    {
        /* �޸� 1 
         * ���߿� �ִ� ���� ���
         * ���� �پ� �ְ�, �׸��� ���� ���� �÷��̾ ����Ű�� ������ �ִٸ�
         */
        if (isGround == false)
        {
            if (touchWall && moveDir.x != 0f && Input.GetKeyDown(KeyCode.Space))
            {
                isWallJump = true;
            }

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
        if (dashTimer > 0.0f)
        {
            return;
        }

        if (isWallJump == true)
        {
            isWallJump = false;

            Vector2 dir = rigid.velocity;
            dir.x *= -1f; // �ݴ���� ���� �������
            rigid.velocity = dir;

            verticalVelocity = jumpForce * 0.5f;
            // ���� �ð� ������ �Է��Ҽ� ����� ���� �߷��� x���� ���� ����
            // �Է� �Ұ� Ÿ�̸Ӹ� �۵� ���Ѿ���
            wallJumpTimer = wallJumpTime;
        }

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
    private void rotatePlayerByMouse()
    {
        Vector2 mouseWorldPos = camMain.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;

        Vector3 playerScale = transform.localScale;
        if (fixedPos.x > 0 && playerScale.x != -1.0f)
        {
            playerScale.x = -1.0f;
        }
        else if (fixedPos.x < 0 && playerScale.x != 1.0f)
        {
            playerScale.x = 1.0f;
        }
        transform.localScale = playerScale;
    }

    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        anim.SetBool("IsGround", isGround);
    }


}
