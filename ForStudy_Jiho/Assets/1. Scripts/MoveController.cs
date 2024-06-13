using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : PlayerStat
{


    

    private void OnDrawGizmos() { if (showGroundCheck) { Debug.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckLength), colorGroundCheck); } }

    

    private void Update()
    {
        checkGround();
        moving();
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



}
