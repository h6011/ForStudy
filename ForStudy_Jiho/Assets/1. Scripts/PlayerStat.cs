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
    /// 변수 채워주는 용
    /// </summary>
    protected virtual void initVars()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        camMain = Camera.main;

        anim = GetComponent<Animator>();

        groundCheckLayerint = LayerMask.GetMask("Wall", "Ground");
    }



    /// <summary>
    /// 점프 강도
    /// </summary>
    [Header("플레이어 수치")]

    [SerializeField] protected float jumpForce;
    /// <summary>
    /// 이동 속도
    /// </summary>
    [SerializeField] protected float moveSpeed;


    //[SerializeField] protected bool showGroundCheck;
    //[SerializeField] protected Color colorGroundCheck;

    [Header("땅 감지")]
    /// <summary>
    /// 이 길이가 게임에서 얼마 만큼의 길이로 나오는지 육안으로 보기 전까지는 알수가 없음
    /// </summary>
    [SerializeField] protected float groundCheckLength;

    [Header("플레이어 스탯")]
    /// <summary>
    /// 땅에 닿았는지 여부
    /// </summary>
    [SerializeField] protected bool isGround;
    /// <summary>
    /// 점프를 하기위해 사용된 bool
    /// </summary>
    protected bool isJump;

    

    /// <summary>
    /// 벽에 닿았는지 아닌지 여부 확인
    /// </summary>
    [Header("벽점프 관련")]
    [SerializeField] protected bool touchWall;
    /// <summary>
    /// 벽점프를 하기 위해 사용된 bool
    /// </summary>
    protected bool isWallJump;
    /// <summary>
    /// 벽점프 시간
    /// </summary>
    [SerializeField] protected float wallJumpTime = 0.3f;
    /// <summary>
    /// 벽점프 타이머
    /// </summary>
    protected float wallJumpTimer = 0.0f;



    /// <summary>
    /// 대쉬 타임
    /// </summary>
    [Header("대쉬")]
    [SerializeField] protected float dashTime = 0.3f;
    /// <summary>
    /// 대쉬 타이머
    /// </summary>
    protected float dashTimer = 0.0f;
    /// <summary>
    /// 대쉬 스피드 (강도)
    /// </summary>
    protected float dashSpeed = 20.0f;
    /// <summary>
    /// 대쉬 키들
    /// </summary>
    [SerializeField] protected List<KeyCode> dashkeys;

    


    /// <summary>
    /// 이동 방향
    /// </summary>
    protected Vector3 moveDir;

    /// <summary>
    /// 수직 속도
    /// </summary>
    protected float verticalVelocity = 0f;












    /// <summary>
    /// 대쉬 키를 눌렀는지 아닌지 Input.KeyDown()
    /// </summary>
    /// <returns>눌렀는지 아닌지 여부 KeyDown</returns>
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
