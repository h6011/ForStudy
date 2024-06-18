using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Vars")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected CapsuleCollider2D coll;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Animator anim;

    [SerializeField] protected int groundCheckLayerint;


    protected virtual void Awake()
    {
        initVars();
    }
    protected virtual void Reset()
    {
        initVars();
    }

    /// <summary>
    /// ���� ä���ִ� ��
    /// </summary>
    protected virtual void initVars()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();

        groundCheckLayerint = LayerMask.GetMask("Wall", "Ground");
    }



    /// <summary>
    /// ���� ����
    /// </summary>
    [Header("�÷��̾� ����")]

    [SerializeField] protected float jumpForce;
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    [SerializeField] protected float moveSpeed;


    [SerializeField] protected bool showGroundCheck;
    [SerializeField] protected Color colorGroundCheck;

    /// <summary>
    /// �� ���̰� ���ӿ��� �� ��ŭ�� ���̷� �������� �������� ���� �������� �˼��� ����
    /// </summary>
    [SerializeField] protected float groundCheckLength;


    /// <summary>
    /// ���� ��Ҵ��� ����
    /// </summary>
    [SerializeField] protected bool isGround;
    /// <summary>
    /// isJump
    /// </summary>
    [SerializeField] protected bool isJump;

    /// <summary>
    /// ���� ��Ҵ��� �ƴ��� ���� Ȯ��
    /// </summary>
    [Header("������ ����")]
    [SerializeField] protected bool touchWall;
    /// <summary>
    /// isWallJump
    /// </summary>
    protected bool isWallJump;
    /// <summary>
    /// ������ �ð�
    /// </summary>
    [SerializeField] protected float wallJumpTime = 0.3f;
    /// <summary>
    /// ������ Ÿ�̸�
    /// </summary>
    protected float wallJumpTimer = 0.0f;



    /// <summary>
    /// �̵� ����
    /// </summary>
    protected Vector3 moveDir;

    /// <summary>
    /// ���� �ӵ�
    /// </summary>
    protected float verticalVelocity = 0f;
    

}
