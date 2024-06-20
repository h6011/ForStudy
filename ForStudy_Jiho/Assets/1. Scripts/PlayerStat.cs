using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [Header("In Vars")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected CapsuleCollider2D coll;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Animator anim;
    [SerializeField] protected TrailRenderer trailRenderer;

    [Header("�뽬 UI ����")]
    [SerializeField] protected GameObject objectdashCoolTime;
    [SerializeField] protected Image imgFill;
    [SerializeField] protected TMP_Text TextCoolTime;

    protected Camera camMain;

    protected int groundCheckLayerint;


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
        trailRenderer = GetComponent<TrailRenderer>();

        camMain = Camera.main;

        anim = GetComponent<Animator>();

        groundCheckLayerint = LayerMask.GetMask("Wall", "Ground");


        trailRenderer.enabled = false;
    }



    /// <summary>
    /// ���� ����
    /// </summary>
    [Header("�÷��̾� ��ġ")]

    [SerializeField] protected float jumpForce;
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    [SerializeField] protected float moveSpeed;


    //[SerializeField] protected bool showGroundCheck;
    //[SerializeField] protected Color colorGroundCheck;

    [Header("�� ����")]
    /// <summary>
    /// �� ���̰� ���ӿ��� �� ��ŭ�� ���̷� �������� �������� ���� �������� �˼��� ����
    /// </summary>
    [SerializeField] protected float groundCheckLength;

    [Header("�÷��̾� ����")]
    /// <summary>
    /// ���� ��Ҵ��� ����
    /// </summary>
    [SerializeField] protected bool isGround;
    /// <summary>
    /// ������ �ϱ����� ���� bool
    /// </summary>
    protected bool isJump;

    

    /// <summary>
    /// ���� ��Ҵ��� �ƴ��� ���� Ȯ��
    /// </summary>
    [Header("������ ����")]
    [SerializeField] protected bool touchWall;
    /// <summary>
    /// �������� �ϱ� ���� ���� bool
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
    /// �뽬 Ÿ��
    /// </summary>
    [Header("�뽬")]
    [SerializeField] protected float dashTime = 0.3f;
    /// <summary>
    /// �뽬 Ÿ�̸�
    /// </summary>
    protected float dashTimer = 0.0f;
    /// <summary>
    /// �뽬 ���ǵ� (����)
    /// </summary>
    protected float dashSpeed = 20.0f;

    [SerializeField] protected float dashCoolTimeTime = 1.5f;
    /// <summary>
    /// �뽬 Ÿ�̸�
    /// </summary>
    protected float dashCoolTimeTimer = 0.0f;


    /// <summary>
    /// �뽬 Ű��
    /// </summary>
    [SerializeField] protected List<KeyCode> dashkeys;

    


    /// <summary>
    /// �̵� ����
    /// </summary>
    protected Vector3 moveDir;

    /// <summary>
    /// ���� �ӵ�
    /// </summary>
    protected float verticalVelocity = 0f;












    /// <summary>
    /// �뽬 Ű�� �������� �ƴ��� Input.KeyDown()
    /// </summary>
    /// <returns>�������� �ƴ��� ���� KeyDown</returns>
    protected virtual bool isPressedDashKey()
    {
        bool isKeyPressed = false;

        int dashkeysListCount = dashkeys.Count;

        for (int iNum = 0; iNum < dashkeysListCount; iNum++)
        {
            KeyCode keycode = dashkeys[iNum];
            if (Input.GetKeyDown(keycode))
            {
                isKeyPressed = true;
                break;
            }
        }

        return isKeyPressed;
    }

















}
