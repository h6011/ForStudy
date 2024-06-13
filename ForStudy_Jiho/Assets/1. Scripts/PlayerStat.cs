using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Vars")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected CapsuleCollider2D coll;
    [SerializeField] protected Animator anim;


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
        anim = GetComponent<Animator>();
    }



    [Header("플레이어 스탯")]

    /// <summary>
    /// 점프 강도
    /// </summary>
    [SerializeField] protected float jumpForce;
    /// <summary>
    /// 이동 속도
    /// </summary>
    [SerializeField] protected float moveSpeed;


    [SerializeField] protected bool showGroundCheck;
    [SerializeField] protected Color colorGroundCheck;

    /// <summary>
    /// 이 길이가 게임에서 얼마 만큼의 길이로 나오는지 육안으로 보기 전까지는 알수가 없음
    /// </summary>
    [SerializeField] protected float groundCheckLength;


    /// <summary>
    /// 땅에 닿았는지 여부
    /// </summary>
    [SerializeField] protected bool isGround;



    /// <summary>
    /// 이동 방향
    /// </summary>
    protected Vector3 moveDir;

    /// <summary>
    /// 수직 속도
    /// </summary>
    protected float verticalVelocity = 0f;
    

}
